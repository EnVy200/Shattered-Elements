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

namespace TrueSoul
{
    public class HolySwordUpgradeProjectile : ModProjectile
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
            Projectile.penetrate = 1;
            Projectile.timeLeft = 800;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        int Timer = 0;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Burning, 150, false);
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Timer++;

            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<YellowDust>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
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
