using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace TrueSoul.Enemies
{
    public class SwordSplitLeft : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SwordSplitLeft"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
                        Projectile.velocity.Y = 0f;
            Projectile.velocity.X = 0f;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 2000;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;

            Projectile.velocity.X = -1f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
          
            base.OnHitPlayer(target, damage, crit);
        }
        int Timer = 0;

        public override void AI()
        {
            Timer++;
            if (Timer < 50)
            {
                Projectile.velocity.X -= 0.5f;
                Projectile.knockBack = 3f;
            }
            if (Timer > 50)
            {
                if  (Timer > 100)
                {
                    if (Timer < 151)
                    {
                        Projectile.velocity.X += 0.5f;
                        Projectile.knockBack = 3f;
                        Projectile.velocity.Y = 0f;
                    }
                    else
                    {
                        Projectile.Kill();
                    }
                }
                else
                {
                    Projectile.velocity.X = 0f;
                    Projectile.velocity.Y = 14f;
                }


            }

  





        }
    }
}