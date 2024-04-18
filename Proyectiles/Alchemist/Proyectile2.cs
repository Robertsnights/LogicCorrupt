using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using LogicCorrupt.DamageClases;
using LogicCorrupt.Utilidades;
using LogicCorrupt.Proyectiles.TypeLess;
using LogicCorrupt.Efectos.Debuff;

namespace LogicCorrupt.Proyectiles.Alchemist
{
    internal class Proyectile2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 200;
            Projectile.tileCollide = true;
            Projectile.DamageType = ModContent.GetInstance<AlchemistClass>();
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            if (Projectile.ai[0]++ > 45f)
            {
                if (Projectile.velocity.Y < 10f)
                {
                    Projectile.velocity.Y += 0.15f;
                }
            }
            Projectile.rotation += MathHelper.ToRadians(Projectile.velocity.Length());
        }
        public override void OnKill(int timeLeft)
        {
            Projectile.ExpandHitboxBy(128);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
            int projAmt = Main.rand.Next(3, 5);
            if (Projectile.owner == Main.myPlayer)
            {
                for (int s = 0; s < projAmt; s++)
                {
                    Vector2 velocity = ApoyoProjectiles.RandomVelocity(100f, 70f, 100f);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, velocity, ModContent.ProjectileType<Reductora>(), Projectile.damage, 0f, Projectile.owner);

                }
                int clodAmt = Main.rand.Next(8, 13);
                for (int c = 0; c < clodAmt; c++)
                {
                    Vector2 velo = ApoyoProjectiles.RandomVelocity(100f, 10f, 200f, 0.01f);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, velo, ModContent.ProjectileType<Reductora>(), (int)(Projectile.damage * 0.5), 0f, Projectile.owner);

                }
            }
            for (int d = 0; d < 5; d++)
            {
                int boom = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Demonite, 0f, 0f, 100, default, 2f);
                Main.dust[boom].velocity *= 3f;
                if (Main.rand.NextBool())
                {
                    Main.dust[boom].scale = 0.5f;
                    Main.dust[boom].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            for (int d = 0; d < 9; d++)
            {
                int fire = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
                Main.dust[fire].velocity *= 5f;
                fire = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
                Main.dust[fire].velocity *= 2f;
            }
            //aqui va el gore
        }

        public override void OnHitNPC(Terraria.NPC target, Terraria.NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<ArmaduraRota>(), 30);
            Projectile.Kill();
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<ArmaduraRota>(), 30);
            Projectile.Kill();
        }
    }
}
