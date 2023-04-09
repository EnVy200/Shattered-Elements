using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;


namespace TrueSoul.Enemies
{
    public class SpreadBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Bomb"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 10000;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.ArmorPenetration = 15;
        }
        int Timer = 0;

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
          
            base.OnHitPlayer(target, damage, crit);
        }


        public override void AI()
        {
            if (Timer <= 5)
            {
                Projectile.velocity.X = 0;
                Projectile.velocity.Y = 0;
            }



            Timer++;
            if (Timer <= 20)
            {
                Projectile.velocity.X = 0;
                Projectile.velocity.Y -= 0.7f;
            }
            if (Timer >= 20)
            {

            }

            if (Timer >= 40)
            {
                Projectile.Kill();
                const int NumProjectiles = 16; // The humber of projectiles that this gun will shoot.

                for (int i = 0; i < NumProjectiles; i++)
                {
                    // Rotate the velocity randomly by 30 degrees at max.
                    Vector2 newVelocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));



                    // Create a projectile.                    // Decrease velocity randomly for nicer visuals.





                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, newVelocity, ModContent.ProjectileType<Spread>(), 36, 1, Main.myPlayer);


                }
               
                Projectile.velocity.Y += 0.1f;
            }

                


               
                   

                   
                }
            
            }

           
        }





    

