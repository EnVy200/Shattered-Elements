using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using TrueSoul.Items.Ranged;
using TrueSoul.Items.Other;
using TrueSoul.Items.Materials;
using TrueSoul.Items.Placeables;
using Terraria.GameContent.Bestiary;


namespace TrueSoul.Enemies.OnyxBiome
{
    public class OnyxGolem : ModNPC
    {
        int FrameX = 0;
        int timePerFrame = 16;
        int MaxFrames = 4;
        private float my_AI_State = 0.0f;
        private int frameHeight;
        private int currentFrame;

        // Here we define an enum we will use with the State slot. Using an ai slot as a means to store "state" can simplify things greatly. Think flowchart.
        private enum ActionState
        {
            Asleep,
            Notice,
            Jump,
            Hover,
            Fall
        }

        // Our texture is 36x36 with 2 pixels of padding vertically, so 38 is the vertical spacing.
        // These are for our benefit and the numbers could easily be used directly in the code below, but this is how we keep code organized.
        private enum Frame
        {
            Asleep,
            Notice,
            Falling,
            Flutter1,
            Flutter2,
            Flutter3
        }

        // These are reference properties. One, for example, lets us write AI_State as if it's NPC.ai[0], essentially giving the index zero our own name.
        // Here they help to keep our AI code clear of clutter. Without them, every instance of "AI_State" in the AI code below would be "npc.ai[0]", which is quite hard to read.
        // This is all to just make beautiful, manageable, and clean code.


        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Onyx Golem");
            //Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
            Main.npcFrameCount[NPC.type] = 12;
        }

        public override void SetDefaults()
        {
            float FrameX = NPC.position.X;
            NPC.width = 60;
            NPC.height = 64;
            NPC.damage = 32;
            NPC.defense = 6;
            NPC.lifeMax = 90;
            NPC.value = 500f;
            NPC.aiStyle = 3;
            NPC.timeLeft = 800;
            NPC.HitSound = SoundID.NPCHit41;
            NPC.DeathSound = SoundID.NPCDeath43;
            NPC.knockBackResist = -999;
            AIType = NPCID.Golem;
            NPC.frame.Height = 64;
            NPC.frame.Width = 60;
            NPC.position.Y += 5;
            NPC.scale = 1.16f;

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A guardian of the onyx caverns. It has been designed to destroy anything in it's path with it's overwhelming power.")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OnyxShardBlack>(), 1, 6, 10));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OnyxShard>(), 3, 4, 6));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GlimmeringOnyxCore>(), 20, 1, 1));


        }
        int WalkFrameTimer = 0;

        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI()
        {
            NPC.TargetClosest();
            if (Main.player[NPC.target].position.X >= NPC.position.X)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            if (Main.player[NPC.target].position.X <= NPC.position.X)
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }

            else
            {
                NPC.dontTakeDamage = false;
            }


        }
        int Timer = 0;
        bool Attacking = false;
        public override void FindFrame(int frameHeight)
        {
            Timer++;
            
            if (Timer > 349)
            {
                Attacking = true;
                NPC.velocity.X = 0;
            }
            else
            {
                Attacking = false;
            }
            if (Attacking == false)
            {
                if (NPC.velocity.X != 0)
                {
                    WalkFrameTimer++;
                    if (WalkFrameTimer <= 12)
                    {
                        NPC.frame.Y = 577;
                    }
                    if (WalkFrameTimer >= 12 && WalkFrameTimer <= 24)
                    {
                        NPC.frame.Y = 641;
                    }
                    if (WalkFrameTimer >= 36)
                    {
                        NPC.frame.Y = 705;

                    }
                    if (WalkFrameTimer == 48)
                    {

                        WalkFrameTimer = 0;
                    }
                }
                else
                {
                    NPC.frame.Y = 1;
                    WalkFrameTimer = 0;
                }
            }
  
            if (Timer == 350) //charge frame 1
            {
                NPC.frame.Y = 65;
            }
            if (Timer == 370)//charge frame 2
            {
                NPC.frame.Y = 129;
            }
            if (Timer == 390)//charge frame 3
            {
                NPC.frame.Y = 193;
            }
            if (Timer == 410)//charge frame 4
            {
                NPC.frame.Y = 257;
            }
            if (Timer == 430)//attack frame 1
            {
                NPC.frame.Y = 321;
            }
            if (Timer == 445)//attack frame 2
            {
                NPC.frame.Y = 385;
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<OnyxianSpike1>(), 16, 0.07f, Main.myPlayer);
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<OnyxianSpike2>(), 16, 0.07f, Main.myPlayer);
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<OnyxianSpike3>(), 16, 0.07f, Main.myPlayer);
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<OnyxianSpike4>(), 16, 0.07f, Main.myPlayer);
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<OnyxianSpike5>(), 16, 0.07f, Main.myPlayer);
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<OnyxianSpike6>(), 16, 0.07f, Main.myPlayer);
            }
            if (Timer == 460)//attack frame 3
            {
                NPC.frame.Y = 449;
            }
            if (Timer == 470)//attack frame 4
            {

                NPC.frame.Y = 513;
            }

            if (Timer == 510)
            {

                Timer = 0;
            }
        }

    }
}

