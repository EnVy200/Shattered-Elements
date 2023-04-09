using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;



namespace TrueSoul.Enemies
{
    public class Spread : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimeball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
           
            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 800;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
        }
        int Timer = 0;
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
          
            base.OnHitPlayer(target, damage, crit);
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
          



            Timer++;
            if (Timer == 1)

            {
                Projectile.damage += 1;
            }

        }


    }
}
