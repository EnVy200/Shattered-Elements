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


namespace TrueSoul.Enemies
{
    public class FlameSlimeInferno : ModNPC
    {
        int FrameX = 0;
        int timePerFrame = 13;
        int MaxFrames = 3;
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
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        public ref float AI_FlutterTime => ref NPC.ai[2];
        public ref float AI_Avoid_Death => ref NPC.ai[3];

        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Inferno");
            //Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            float FrameX = NPC.position.X;
            NPC.width = 150;
            NPC.height = 150;
            NPC.damage = 89;
            NPC.defense = 6;
            NPC.lifeMax = 10000;
            NPC.value = 0f;
            NPC.aiStyle = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.KingSlime;
            AnimationType = NPCID.GreenSlime;

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
            base.OnHitPlayer(target, damage, crit);
        }
        public override void OnSpawn(IEntitySource source)
        {
            NPC.position.X += -100;
            base.OnSpawn(source);
        }


        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            
            


        }
        int Timer = 0;
        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI()
        {
            
            Timer++;
            if (Timer == 60)
            {
                Timer = 0;
            }
            if (Timer > 30)
            {
                NPC.velocity.X = 10;
                NPC.velocity.Y = -5;
            }
            else
            {
                NPC.velocity.X = -10;
                NPC.velocity.Y = 10;
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
}
