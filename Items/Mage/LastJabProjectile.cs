using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Ranged;

namespace TrueSoul.Items.Mage
{
    public class LastJabProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strong Laser"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 60;
            Projectile.light = 2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }


        public override void Kill(int timeLeft)
        {
            if (Projectile.timeLeft <= 0)
            {
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<LastJabProjectile>(), 30, 1, Main.myPlayer);
            }
        }

    }
}