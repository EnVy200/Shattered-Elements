using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TrueSoul.Items.Melee
{
    public class RightStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.velocity.Y = 0f;
            Projectile.velocity.X = 0f;
            Projectile.width = 40;

            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 160;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.minion = true;
            Projectile.ArmorPenetration = 255;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position = Main.MouseWorld;
            Projectile.position.Y -= 8;
            
        }
        public override bool PreAI()
        {
            
            return base.PreAI();
        }
        public override void AI()
        {
            if (Projectile.velocity.LengthSquared() < 2 * 2)
            {
                Projectile.position.X -= 8;
            }
            else
            {
                Projectile.velocity.X += 0.25f;
            }

        }
    }
}