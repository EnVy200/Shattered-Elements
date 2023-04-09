using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Ranged;

namespace TrueSoul.Items.Elementalist
{
    public class WindsweptSawblade : ModProjectile
    {
        float speed;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Windswept Saw"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[Projectile.type] = 1;
        }


        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 68;
            Projectile.height = 68;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 8;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 130;

            Projectile.light = 0.1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            
            
        }
        int Timer = 0;

   
        public override void AI()
        {

            Projectile.alpha += 3;
            Projectile.velocity.X *= 0.98f;
            Projectile.velocity.Y *= 0.98f;
            Projectile.rotation += 6;
            

            
            base.AI();
        }





    }
}
   