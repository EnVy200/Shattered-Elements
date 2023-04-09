using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TrueSoul.Dusts;
using Terraria.ID;

namespace TrueSoul.Items.Melee
{
    public class RealKnifeDevItemProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimeball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 999;
            Projectile.timeLeft = 800;
            Projectile.light = 1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        int Timer = 0;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Bleeding, 1000, false);
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Timer++;

            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            if (Timer == 1)
            {
                Projectile.damage += 6;
            }
            if (Timer == 37)
            {
                Timer = 0;
            }

        }

    }
}
