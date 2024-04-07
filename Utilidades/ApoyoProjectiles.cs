using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace LogicCorrupt.Utilidades
{
    internal static partial class ApoyoProjectiles
    {
        public static bool AnyProjec(int projetileID)
        {
            for (int i = 0; i < projetileID; i++)
            {
                Projectile p = Main.projectile[i];
                if (p.type != projetileID || !p.active)
                {
                    continue;
                }

                return true;
            }
            return false;
        }

        public static IEnumerable<Projectile> TodoProjectilePorID(int projectileID)
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];
                if (p.type != projectileID || !p.active) continue;

                yield return p;
            }
        }

        public static int CountPtojectiles(int projectileID) => Main.projectile.Count(proj => proj.type == projectileID && proj.active);

        public static int CountHookProj() => Main.projectile.Count(proj => Main.projHook[proj.type] && proj.ai[0]
        == 2f && proj.active && proj.owner == Main.myPlayer);

        public static bool FinalExtraUpdate(this Projectile proj) => proj.numUpdates == -1;

        #region AI necesaria
        public static void ExpandHitboxBy(this Projectile p, int width, int height)
        {
            p.position = p.Center;
            p.width = width;
            p.height = height;
            p.position -= p.Size * 0.5f;
        }
        public static void ExpandHitboxBy(this Projectile projectile, int newSize) => projectile.ExpandHitboxBy(newSize, newSize);
        public static void ExpandHitboxBy(this Projectile projectile, Vector2 newSize) => projectile.ExpandHitboxBy((int)newSize.X, (int)newSize.Y);
        public static void ExpandHitboxBy(this Projectile projectile, float expandRatio) => projectile.ExpandHitboxBy((int)(projectile.width * expandRatio), (int)(projectile.height * expandRatio));
        public static void HomeInOnNPC(Projectile projectile, bool ignoreTiles, float distanceRequired, float homingVelocity, float N)
        {
            if (!projectile.friendly)
                return;
            Vector2 destino = projectile.Center;
            float distanciaMax = distanceRequired;
            bool objLocalizado = false;
            for(int i =0; i < Main.maxNPCs; i++)
            {
                float extraDistancia = (Main.npc[i].width / 2) + (Main.npc[i].height / 2);
                if (!Main.npc[i].CanBeChasedBy(projectile, false) || !projectile.WithinRange(Main.npc[i].Center, distanciaMax + extraDistancia))
                {
                    continue;
                }
                if(ignoreTiles|| Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
                {
                    destino = Main.npc[i].Center;
                    objLocalizado = true;
                    break;
                }
                
                
            }
            if (objLocalizado)
            {
                Vector2 homeDirection = (destino - projectile.Center).SafeNormalize(Vector2.UnitY);
                projectile.velocity = (projectile.velocity * N + homeDirection * homingVelocity) / (N + 1f);

            }
        }
        public static Vector2 CalculatePredictiveAim(Vector2 startingPosition, Vector2 targetPosition, Vector2 targetVelocity, float shootSpeed, int iterations = 4)
        {
            float previoTimeToReach = 0f;
            Vector2 currentTargetPOsition = targetPosition;
            for(int i = 0; i < iterations; i++)
            {
                float timeToReach = Vector2.Distance(startingPosition, currentTargetPOsition) / shootSpeed;
                currentTargetPOsition += targetVelocity * (timeToReach - previoTimeToReach);
                previoTimeToReach = timeToReach;
            }
            return (currentTargetPOsition - startingPosition).SafeNormalize(Vector2.UnitY) * shootSpeed;
        }
        /*
        public static Vector2 CalculatePredictiveAimToTarget(Vector2 startingPosition, Vector2 Center, Entity target, float shootSpeed, int iterations = 4)
        {
            return CalculatePredictiveAimToTarget(startingPosition, target.Center, target.velocity, shootSpeed, iterations);
        }
        public static Vector2 SuperhomeTowardsTarget(this Projectile projectile, NPCID target, float homingSpeed, float inertia, float predictionStrength = 1f)
        {
            if (predictionStrength < 0.01f) { predictionStrength = 0.01f; }

            return ((projectile.velocity * (inertia - 1f)) + (Vector2)(CalculatePredictiveAimToTarget(Center, target, homingSpeed / predictionStrength) * predictionStrength)) / inertia;
        }
        */


        public static Vector2 RandomVelocity(float directionMult, float speedLowerLimit, float speedCap, float speedMult = 0.1f)
        {
            Vector2 velocity = new Vector2(Main.rand.NextFloat(-directionMult, directionMult), Main.rand.NextFloat(-directionMult, directionMult));
            //Rerolling to avoid dividing by zero
            while (velocity.X == 0f && velocity.Y == 0f)
            {
                velocity = new Vector2(Main.rand.NextFloat(-directionMult, directionMult), Main.rand.NextFloat(-directionMult, directionMult));
            }
            velocity.Normalize();
            velocity *= Main.rand.NextFloat(speedLowerLimit, speedCap) * speedMult;
            return velocity;
        }
        #endregion
    }
}
