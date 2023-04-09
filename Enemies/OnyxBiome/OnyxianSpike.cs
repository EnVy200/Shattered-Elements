using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TrueSoul.Dusts;

namespace TrueSoul.Enemies.OnyxBiome
{

        public class OnyxianSpike1 : ModProjectile
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Onyxian Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

            }
            public override void OnSpawn(IEntitySource source)
            {
            Projectile.position.X += 50;
                
                base.OnSpawn(source);
            }
            public override void SetDefaults()
            {
                //Projectile.magic = true;
                Projectile.width = 14;
                Projectile.height = 26;
                Projectile.friendly = false;
                Projectile.hostile = true;
                Projectile.aiStyle = 0;
                Projectile.penetrate = 3;
                Projectile.timeLeft = 200;
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
            Timer++;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Timer >= 15)
            {
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity.X = 1;
            }
            else
            {
                Projectile.velocity.Y = -4;
                Projectile.velocity.X = 2;
            }

        }


        }
    public class OnyxianSpike2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyxian Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.X += 100;

            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 14;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 200;
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
            Timer++;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Timer >= 15)
            {
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity.X = 1;
            }
            else
            {
                Projectile.velocity.Y = -4;
                Projectile.velocity.X = 2;
            }
        }


    }
    public class OnyxianSpike3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyxian Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.X += 150;

            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 14;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 200;
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
            Timer++;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Timer >= 15)
            {
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity.X = 1;
            }
            else
            {
                Projectile.velocity.Y = -4;
                Projectile.velocity.X = 2;
            }
        }


    }
    public class OnyxianSpike4 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyxian Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.X -= 50;

            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 14;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 200;
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
            Timer++;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Timer >= 15)
            {
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity.X = -1;
            }
            else
            {
                Projectile.velocity.Y = -4;
                Projectile.velocity.X = -2;
            }
        }


    }
    public class OnyxianSpike5 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyxian Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.X -= 100;

            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 14;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 200;
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
            Timer++;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Timer >= 15)
            {
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity.X = -1;
            }
            else
            {
                Projectile.velocity.Y = -4;
                Projectile.velocity.X = -2;
            }
        }


    }
    public class OnyxianSpike6 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyxian Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.X -= 150;

            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 14;
            Projectile.height = 26;

            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 200;
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
            Timer++;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Timer >= 15)
            {
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity.X = -1;
            }
            else
            {
                Projectile.velocity.Y = -4;
                Projectile.velocity.X = -2;
            }





        }


    }
    public class OnyxianSpikeNoDirection : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyxian Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
          

            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 14;
            Projectile.height = 26;

            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 200;
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
            Timer++;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Timer >= 15)
            {
                Projectile.velocity.Y += 0.2f;
                
            }
            else
            {
                Projectile.velocity.Y = -4;
             
            }





        }


    }
}


