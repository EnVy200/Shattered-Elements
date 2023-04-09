using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TrueSoul.Dusts;


namespace TrueSoul.Items.Melee
{
    public class MagmaScytheProjectile : ModProjectile
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
            Projectile.timeLeft = 2000;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        int Timer = 0;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           
        }
        public override void AI()
        {
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<OrangeSparkle>(), Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation += 0.33f;
            Timer++;
            if (Timer == 1)
            {
                Projectile.damage += 1;
            }
            
        }

       
    }
}
