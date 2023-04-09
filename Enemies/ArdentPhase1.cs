using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using TrueSoul.Items.Ranged;
using TrueSoul.Items.Melee;
using TrueSoul.Items.Other;
using TrueSoul.Items.Mage;

using TrueSoul.Dusts;

namespace TrueSoul.Enemies
{
    public class ArdentPhase1 : ModNPC
    {
        int FrameX = 0;
        int timePerFrame = 9;
        int MaxAttackCooldown = 13;
        int MaxFrames = 5;
        int AttackCooldown = 0;
        int ShootProj = 0;
        int AttackCooldown2 = 0;
        int AttackNumber = 4;








        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Ardent");
            //Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void OnSpawn(IEntitySource source)
        {
            NPC.velocity.Y = -20;
            base.OnSpawn(source);
        }

        public override void SetDefaults()
        {
            float FrameX = NPC.position.X;
            NPC.width = 63;
            NPC.height = 98;
            NPC.damage = 69;
            NPC.defense = 16;
            NPC.lifeMax = 75000;
            NPC.value = 500f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.noGravity = true;
            NPC.boss = true;
            NPC.knockBackResist = -999f;

            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/Melting_Point");
            }




        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            NPC.position.Y -= 2.5f;
            base.OnHitByProjectile(projectile, damage, knockback, crit);
        }
        public override void OnKill()
        {
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f); Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f); Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f); Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<RedSparkleAllDir>(), 2f, 2f, Alpha: 128, Scale: 1.2f);

            base.OnKill();
        }


        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
           
        }
        int Plus2 = 0;
        int Phase = 0;
        bool SummonEvenMoreSlimes = true;
        bool Continue = true;

        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI()
        {
            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ElementLaser>(), 50, 0.07f, Main.myPlayer, NPC.whoAmI);
            NPC.position.Y += 0.25f;
            if (NPC.velocity.Y != 0)
            {
                NPC.velocity.Y += 0.5f;
            }
            if (NPC.AnyNPCs(ModContent.NPCType<FlameSlimeInferno>()))
            {
                NPC.dontTakeDamage = true;
            }

            if (NPC.AnyNPCs(ModContent.NPCType<FlameSlimeInferno>()))
            { }

            else
            {
                if (NPC.AnyNPCs(ModContent.NPCType<FlameSlimeBurn>()))
                { }

                else
                {
                    NPC.dontTakeDamage = false;
                }
            }
            ShootProj++;
            AttackCooldown++;
            Plus2++;

            if (NPC.life >= NPC.lifeMax * 0.67)//Detects if the life is higher than 67 percent of the max health, if so, set the phase to 1.
            {
                Phase = 1;

            }
            if (NPC.life <= NPC.lifeMax * 0.67)//Detects if the life is less than 67 percent of the max health, if so, set the phase to 2.
            {
                if (NPC.life >= NPC.lifeMax * 0.45)//Detects if the life is less than 67 percent of the max health, and if it is greater than 0.47 percent of the max health.  If so, set the phase to 2.
                {
                    Phase = 2;
                }
                else //If the health is less than 45 percent set Phase to 3
                {
                    Phase = 3;
                }
            }
            if (Phase == 2)
            {
                if (SummonEvenMoreSlimes == true)//Makes it so it doesn't summon repeatedly
                {
                    NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<FlameSlimeBurn>());
                    NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<FlameSlimeInferno>());
                    SummonEvenMoreSlimes = false;
                }
            }
            if (Phase == 3)
            {
                if (SummonEvenMoreSlimes == true)
                {
                    NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<FlameSlimeBurn>());
                    NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<FlameSlimeInferno>());
                    SummonEvenMoreSlimes = false;
                }
                if (SummonEvenMoreSlimes == false)
                {
                    if (Continue == true)
                    {
                        SummonEvenMoreSlimes = true;
                        Continue = false;
                    }

                }

            }
            if (Phase == 1)
            {
                if (Plus2 == 50)
                {

                    Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeballTop>(), 50, 0.07f, Main.myPlayer);
                    Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeball>(), 50, 0.07f, Main.myPlayer);

                    Plus2 = 0;

                }
            }
            if (Phase == 2)
            {
                if (Plus2 == 50)
                {
                    Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeball>(), 50, 0.07f, Main.myPlayer);
                    Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeball>(), 50, 0.07f, Main.myPlayer);

                    Plus2 = 0;

                }
            }

            if (Phase == 3)
            {
                if (Plus2 == 50)
                {
                    Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeball>(), 50, 0.07f, Main.myPlayer);
                    Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeball>(), 50, 0.07f, Main.myPlayer);
                    Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeballTop>(), 50, 0.07f, Main.myPlayer);

                    Plus2 = 0;

                }
            }


            if (AttackCooldown > MaxAttackCooldown)
            {
                AttackCooldown2 += 1;
                AttackCooldown = 0;
            }
            if (ShootProj == 6)
            {
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitLeft>(), 300, 0.07f, Main.myPlayer);
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitRight>(), 300, 0.07f, Main.myPlayer);
                ShootProj = 0;
            }
            if (AttackCooldown2 == 15)

            {
                if (Phase == 1)
                {
                    int NumProjectiles = Main.rand.Next(3, 5);//3, 4
                    if (NumProjectiles == 3)
                    {
                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeballTop>(), 50, 0.07f, Main.myPlayer);
                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeball>(), 50, 0.07f, Main.myPlayer);
                    }
                    else
                    {

                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeball>(), 50, 0.07f, Main.myPlayer);
                    }
                }




                if (AttackCooldown2 == 15)

                {


                    AttackNumber = Main.rand.Next(3, 9);//Shuffles the attack number for u
                    if (Phase == 1)
                    {

                        if (AttackNumber == 3)
                        {

                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SpreadBomb>(), 117, 2, Main.myPlayer);
                        }
                        if (AttackNumber == 4)
                        {

                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<FlamingEyeballTop>(), 60, 0.07f, Main.myPlayer);
                        }
                        if (AttackNumber == 5)
                        {

                            NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<BurntSlime>());


                        }
                        if (AttackNumber == 6)
                        {

                            NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<BurntSlime>());
                        }
                        if (AttackNumber == 7)
                        {

                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SplitSword>(), 130, 2, Main.myPlayer);
                        }
                        if (AttackNumber == 8)
                        {

                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 50, 2, Main.myPlayer);
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 50, 2, Main.myPlayer);
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 50, 2, Main.myPlayer);
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 50, 2, Main.myPlayer);
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 50, 2, Main.myPlayer);
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 50, 2, Main.myPlayer);

                        }
                    }
                    AttackNumber = Main.rand.Next(3, 9);//This randomizes the attack so it isn't a set pattern.
                    if (Phase == 2)
                    {
                        if (AttackNumber == 3)
                        {
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SpreadBomb>(), 117, 2, Main.myPlayer);
                        }
                        if (AttackNumber == 4)
                        {
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SpreadBomb>(), 117, 2, Main.myPlayer);
                        }
                        if (AttackNumber == 5)
                        {
                            NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<BurntSlime>());


                        }
                        if (AttackNumber == 6)
                        {
                            NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<BurntSlime>());
                        }
                        if (AttackNumber == 7)
                        {
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SpreadBomb>(), 117, 2, Main.myPlayer);
                        }
                        if (AttackNumber == 8)
                        {
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 100, 2, Main.myPlayer);
                            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 100, 2, Main.myPlayer);


                        }
                    }


                    AttackCooldown2 = 0;
                    AttackNumber = Main.rand.Next(3, 6);//3, 4, or 5
                    AttackNumber = Main.rand.Next(3, 6);//3, 4, or 5
                    AttackNumber = Main.rand.Next(3, 6);//3, 4, or 5
                    AttackNumber = Main.rand.Next(3, 6);//3, 4, or 5
                }
                Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<ExplosionDust>(), 2f, 2f, Alpha: 128, Scale: 1.2f);


            }
            bool IsAnAttack = false;
            if (AttackCooldown2 == 8)
            {
                AttackNumber = Main.rand.Next(3, 9);//3, 4, or 5
                if (Phase == 3)
                {
                    if (AttackNumber == 3)
                    {

                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 100, 2, Main.myPlayer);
                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 100, 2, Main.myPlayer);
                    }
                    if (AttackNumber == 4)
                    {
                        NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<BurntSlime>());

                    }
                    if (AttackNumber == 5)
                    {
                        NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<BurntSlime>());


                    }
                    if (AttackNumber == 6)
                    {
                        NPC.NewNPCDirect(NPC.GetSource_FromAI(), NPC.Center, ModContent.NPCType<BurntSlime>());
                    }
                    if (AttackNumber == 7)
                    {
                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SpreadBomb>(), 117, 2, Main.myPlayer);
                    }
                    if (AttackNumber == 8)
                    {
                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 100, 2, Main.myPlayer);
                        Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<MagmaticDroppingSword>(), 100, 2, Main.myPlayer);


                    }
                    AttackCooldown2 = 0;
                }

            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter > timePerFrame)
            {
                NPC.frameCounter = 0;
                FrameX++;
            }
            if (FrameX >= MaxFrames)
            {
                FrameX = 0;
            }
            base.FindFrame(frameHeight);
            NPC.frame.Y = FrameX * frameHeight;



        }

    }
    public class SplitSword : ModProjectile //A projectile Ardent shoots.
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

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

        }
        int Timer = 0;
        int Phase = 1;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           
        }
        public override void AI()
        {


            Projectile.velocity.X = 0f;


            Timer++;
            if (Timer <= 20)
            {
                Projectile.velocity.Y -= 0.8f;

            }
            if (Timer == 20)
            {

                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitRight>(), 60, 2, Main.myPlayer);
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitLeft>(), 60, 2, Main.myPlayer);

            }
            if (Timer >= 20)
            {
                if (Timer <= 30)
                {
                    Projectile.velocity.Y = 0f;
                    Projectile.velocity.X = 0f;
                }

            }
            if (Timer == 30)
            {
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitRight>(), 60, 2, Main.myPlayer);

            }
            if (Timer >= 30)
            {
                Projectile.velocity.Y += 1f;
            }
            if (Timer == 40)
            {

                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitLeft>(), 60, 2, Main.myPlayer);
            }
            if (Timer == 50)
            {

                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitLeft>(), 60, 2, Main.myPlayer);
            }
            if (Timer == 60)
            {
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitRight>(), 60, 2, Main.myPlayer);

            }
            if (Timer >= 90)
            {
                Projectile.velocity.X = 0f;
                Timer -= 80;
            }
            base.AI();
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitRight>(), 60, 2, Main.myPlayer);
            Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SwordSplitLeft>(), 60, 2, Main.myPlayer);
            return base.OnTileCollide(oldVelocity);
        }


    }

    public class MagmaticDroppingSword : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

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

        }
        int Timer = 0;
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.X += Main.rand.Next(-560, 560);
            base.OnSpawn(source);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
           
            base.OnHitPlayer(target, damage, crit);
        }
        public override void AI()
        {

            Projectile.velocity.X = 0f;


            Timer++;
            if (Timer <= 20)
            {
                Projectile.velocity.Y -= 0.8f;

            }
            if (Timer == 20)
            {

                Projectile.velocity.Y = 9f;

            }




        }
    }
}
