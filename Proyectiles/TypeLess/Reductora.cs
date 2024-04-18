using LogicCorrupt.Efectos.Debuff;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LogicCorrupt.Proyectiles.TypeLess
{
    internal class Reductora : ModProjectile
    {
        public new string LocalizationCategory => "Projectile.Typeless";

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 10;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 30;
            Projectile.friendly = false;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 400;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 6;

        }
        public override void AI()
        {
            Projectile.ai[0] += 1f;
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 6)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.ai[0] < 200)
            {
                if (Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
            else if (Projectile.owner == Main.myPlayer && Projectile.frame >= Main.projFrames[Projectile.type])
            {
                Projectile.Kill();
            }
            Projectile.velocity *= 0.9f;
            if (Projectile.alpha > 80)
            {
                Projectile.alpha -= 30;
                if (Projectile.alpha < 80)
                {
                    Projectile.alpha = 80;
                }
            }
            if (Math.Abs(Projectile.velocity.X) > 0.1f)
            {
                Projectile.spriteDirection = Projectile.direction;
            }

        }
        public override void OnHitNPC(Terraria.NPC target, Terraria.NPC.HitInfo hit, int damageDone) => target.AddBuff(ModContent.BuffType<ArmaduraRota>(), 40);
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<ArmaduraRota>(), 40);
        }
    }
}
