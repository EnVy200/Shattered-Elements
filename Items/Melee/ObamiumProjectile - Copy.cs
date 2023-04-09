using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace TrueSoul.Items.Melee
{
    public class TitaniumAttack : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Bolt"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 10000;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.ArmorPenetration = 15;
        }
        int Timer = 0;
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position = Main.MouseWorld;
            Projectile.position.Y -= 8;
        }
        public override void AI()
        {




            Timer++;
            if (Timer <= 20)
            {
                Projectile.velocity.X = 0f;
                Projectile.velocity.Y -= 0.14f;
            }

          if (Timer >= 20)
            {
                    Projectile.velocity.Y += 1f;    
            }
            if (Timer >= 90)
            {
                Projectile.velocity.X = 0f;
                Timer -= 80;
            }
            base.AI();
        }





    }
}