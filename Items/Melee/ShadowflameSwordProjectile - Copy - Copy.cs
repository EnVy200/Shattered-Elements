using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TrueSoul.Dusts;

namespace TrueSoul.Items.Melee
{
    public class RedSpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 250;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
           
        }
        float x = MathHelper.PiOver2 * 1;

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<RedProjectileTrail>(), Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, Alpha: 128, Scale: 1.2f);


        }
    }
}