 using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Ranged;
using System.Collections.Generic;


namespace TrueSoul.Items.Elementalist
{
    public class PlasmaRayProjectile : ModProjectile
    {
        NPC enemy;
        float speed = 12f;
        List<int> enemiesHit = new List<int>();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ray"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[Projectile.type] = 4;
        }


        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 16;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 12;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 1000;
            Projectile.light = 0.1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            
            Projectile.alpha = 255;
        }
        int Timer = 0;
        int nearestNPC;
        public override void OnSpawn(IEntitySource source)
        {

        }
        public override void AI()
        {

            Dust.NewDustPerfect(Projectile.position, DustID.DemonTorch, null, 20, default);

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            
            base.AI();
        }
        int NewTarget(float range)
        {
            float num1 = range;
            int targetWithLineOfSight = -1;

            for (int index = 0; index < 200; ++index)
            {
                NPC npc = Main.npc[index];
                bool flag = npc.CanBeChasedBy(Projectile);
                if (Projectile.localNPCImmunity[index] != 0)
                    flag = false;
                if (flag)
                {
                    float num2 = Projectile.Distance(Main.npc[index].Center);
                    if ((double)num2 < (double)num1 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height))
                    {
                        if (!enemiesHit.Contains(npc.whoAmI))
                        {
                            num1 = num2;
                            targetWithLineOfSight = npc.whoAmI;


                        }

                    }
                }
            }

            return targetWithLineOfSight;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            enemiesHit.Add(target.whoAmI);
            int enem = NewTarget(250f); //set the float value to the range
            if (enem != -1)
            {
                enemy = Main.npc[enem]; //set the float value to the range
            }
            else
            {
                enemy = new NPC();
                Projectile.Kill();
            }
                Projectile.velocity = Projectile.DirectionTo(enemy.Center) * speed;




            Projectile.damage -= 2;
                
        }



    }
}
   