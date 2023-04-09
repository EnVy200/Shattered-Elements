using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueSoul.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace TrueSoul.Enemies
{

    

   
    
        public class Meteor : ModProjectile
        {
        int speed = 1;
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Diamond Bolt"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

            }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position += Projectile.velocity;
            Projectile.velocity *= Vector2.UnitX.RotatedByRandom(MathHelper.Pi) * speed; // Multiply the dust's start velocity by 0.4, slowing it down
            base.OnSpawn(source);
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
        public override void PostAI()
        {
            Projectile.position += Projectile.velocity;
            base.PostAI();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
            Projectile.Kill();
            // The humber of projectiles that this gun will shoot.
            

            
            return base.OnTileCollide(oldVelocity);


        }



        public override void AI()
            {


            Projectile.position += Projectile.velocity;











        }

        }


    }








