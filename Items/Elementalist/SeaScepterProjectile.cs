using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Ranged;

namespace TrueSoul.Items.Elementalist
{
    public class SeaScepterProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[Projectile.type] = 4;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            damage -= 1;
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 16;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 8;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 1000;
            Projectile.light = 0.1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            
            Projectile.alpha = 255;
        }
        int Timer = 0;

   
        public override void AI()
        {
            Dust.NewDustPerfect(Projectile.position, DustID.BlueTorch, null, 50, default);
            Timer++;
            if (Timer < 35/8)
            {
                Projectile.velocity.Y = 30;
            }
            if (Timer < 175 / 8 && Timer > 35 / 8)
            {
                Projectile.velocity.Y = -30;
            }
            if (Timer < 175 / 8 && Timer > 105/8)
            {
                Projectile.velocity.Y = 30;
            }
            if (Timer > 175 / 8)
            {
                Timer = 35/8;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            
            base.AI();
        }





    }
}
   