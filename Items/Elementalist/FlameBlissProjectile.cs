using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Ranged;

namespace TrueSoul.Items.Elementalist
{
    public class FlameBlissProjectileUpward : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[Projectile.type] = 4;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff((BuffID.OnFire), 240, false);
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 16;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 1000;
            Projectile.light = 2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        int Timer = 0;
        public override void AI()
        {
            Timer++;

            
            Projectile.velocity.Y -= 0.03f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.frameCounter++;
            if (Projectile.frameCounter == 8)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
                if (Projectile.frame == 4)
                {
                    Projectile.frame = 1;
                }
            }
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 2f, 2f, Alpha: 128, Scale: 1.2f);
            base.AI();
        }

        
        


    }
    public class FlameBlissProjectileDownward : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[Projectile.type] = 4;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff((BuffID.OnFire), 240, false);
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 16;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 1000;
            Projectile.light = 2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        int Timer = 0;
        public override void AI()
        {
            Timer++;

            Projectile.velocity.Y += 0.03f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.frameCounter++;
            if (Projectile.frameCounter == 8)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
                if (Projectile.frame == 4)
                {
                    Projectile.frame = 1;
                }
            }
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 2f, 2f, Alpha: 128, Scale: 1.2f);
            base.AI();
        }



    }
    public class FlameBlissProjectileFoward : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[Projectile.type] = 4;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff((BuffID.OnFire), 240, false);
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 16;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 5;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 1000;
            Projectile.light = 2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        int Timer = 0;
        public override void AI()
        {

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.frameCounter++;
            if (Projectile.frameCounter == 8)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
                if (Projectile.frame == 4)
                {
                    Projectile.frame = 1;
                }
            }
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 2f, 2f, Alpha: 128, Scale: 1.2f);
            base.AI();
        }

    }
}