using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TrueSoul.Items.Melee
{
    public class ShadowflameSwordProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 160;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
        }
        

        public override void AI()
        {
            Projectile.velocity.X += 0.25f;
            Projectile.velocity.Y += 0.06f;
        }
    }
}