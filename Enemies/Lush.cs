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


namespace TrueSoul.Enemies
{
    public class Lush : ModNPC
    {
        int FrameX = 0;
        int timePerFrame = 16;
        int MaxFrames = 4;
        private float my_AI_State = 0.0f;
        private int frameHeight;
        private int currentFrame;
        private bool turtleShell = false;


        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Lush");
            //Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
            Main.npcFrameCount[NPC.type] = 12;
        }

        public override void SetDefaults()
        {
            float FrameX = NPC.position.X;
            NPC.width = 60;
            NPC.height = 64;
            NPC.damage = 32;
            NPC.defense = 20;
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
        void Spikes()
        {

            for (i = 0; i < 5; i++)
            {
                Vector2 NewVelocity = Vector2.Zero.RotatedByRandom(MathHelper.ToRadians(50));
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + 60), Vector2.Zero, ModContent.ProjectileType<SharpthornOrigin>(), 50, 0.07f, Main.myPlayer);
            }
  
                

        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Originates from the ancient dryads, whom created this beast out of leaves, wood, and magic. The first of many to come.")
            });
        }
        void DualShell()
        {
            float projectileSpeed = 6;
            Vector2 zero = new Vector2(0, 0);
            Vector2 NewVelocity = zero.RotatedBy(MathHelper.ToRadians(20)) * projectileSpeed;

            float AddToX = 20;
            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + 60), NewVelocity, ModContent.ProjectileType<Shell>(), 50, 0.07f, Main.myPlayer, AddToX);
            AddToX = -20;
            NewVelocity = zero.RotatedBy(MathHelper.ToRadians(-20)) * projectileSpeed;
            Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + 60), NewVelocity, ModContent.ProjectileType<Shell>(), 50, 0.07f, Main.myPlayer, AddToX);
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OnyxShardBlack>(), 1, 6, 10));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OnyxShard>(), 3, 4, 6));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GlimmeringOnyxCore>(), 20, 1, 1));


        }
        int WalkFrameTimer = 0;
        void ShellTransform()
        {
            turtleShell = true;
            NPC.velocity = NPC.velocity.RotatedByRandom(MathHelper.ToRadians(360)) * 4;
            NPC.dontTakeDamage = true;
        }
        void RandomAtkNonShell()
        {
            int RNG = Main.rand.Next(1, 4);
 
            if (RNG == 1)
            {
                Spikes();
            }

            if (RNG == 2)
            {
                DualShell();
            }
            if (RNG == 3)
            {
                ShellTransform();
            }
        }
        void SlowDown()
        {
            if (NPC.velocity.X < 0)
            {
                NPC.velocity.X += 0.1f;
            }
            else
            {
                NPC.velocity.X -= 0.1f;
            }
            if (NPC.velocity.Y < 0)
            {
                NPC.velocity.Y += 0.1f;
            }
            else
            {
                NPC.velocity.Y -= 0.1f;
            }
        }
        int i = 0;

        void AltProjectiles()
        {
            int NumberProjectiles = 10;
            float Change = 360 / NumberProjectiles;

            for (i = 0; i < NumberProjectiles; i++)
            {
                Vector2 NewVelocity = Vector2.Zero.RotatedBy(MathHelper.ToRadians(Change));
                Projectile.NewProjectileDirect(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ThornsLush>(), 50, 0.07f, Main.myPlayer );
                Change += 360 / NumberProjectiles;
            }


        }
        void DashTorward()
        {
            
            SlowDown();
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
            if (i < 15)
            {
                i++;
                DashTorward();
            }
            else
            {
                i = 0;
            }
        }
        int turtleProjectileTimer = 0;
        int amount = 0;
        int amountMax = 4;
        int Timer2 = 0;
        int Timer3 = 0;
        int StartTimer = 0;
        public override void OnKill()
        {
            base.OnKill();
        }
        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI()
        {
            NPC.noGravity = true;
            StartTimer++;
            if (StartTimer !< 30)
            {
                NPC.position.Y -= 10;
            }
            
            Timer++;
            Timer2++;
            if (turtleShell == true)
            {
                NPC.dontTakeDamage = true;
                turtleProjectileTimer++;
                if (turtleProjectileTimer == 50)
                {
                    AltProjectiles();
                    amount++;
                    turtleProjectileTimer = 0;
                }
                if (amount > amountMax)
                {
                    amount = 0;
                    turtleShell = false;
                    
                }
                if (NPC.collideX == true)
                {
                    NPC.velocity = NPC.velocity.RotatedByRandom(MathHelper.ToRadians(25)) * 4;
                }
                if (NPC.collideY == true)
                {
                    NPC.velocity = NPC.velocity.RotatedByRandom(MathHelper.ToRadians(25)) * 4;
                }
                if (Timer > 120)
                {
                    AltProjectiles();
                    Timer = 0;
                }
                if(Timer3 < 600)
                {
                    NPC.velocity = Vector2.Zero;
                    NPC.dontTakeDamage = false;
                    turtleShell = false;

                    Timer3 = 0;

                }
            }
            else
            {
                NPC.dontTakeDamage = false;
                NPC.velocity = Vector2.Zero;

                if (Timer2 == 150)
                {
                    RandomAtkNonShell();

                    Timer2 = 0;

                }
            }




            
            

        }
        int Timer = 0;
        bool Attacking = false;


    }
    public class ThornsLush : ModProjectile
    {
        int speed = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

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
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 10000;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.ArmorPenetration = 2;
        }
        int Timer = 0;

        public override void PostAI()
        {

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            Projectile.Kill();
            // The humber of projectiles that this gun will shoot.



            return base.OnTileCollide(oldVelocity);


        }



        public override void AI()
        {
            Projectile.velocity.Y += 0.05f;
        }

    }

    public class SharpthornOrigin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        int offSet = 10;
        float MagnitudeX;
        float MagnitudeY;
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.Y += 150;
            for (int Length = 0; Length < 20; Length++)
            {
                if (Projectile.velocity.Y < 0)
                {
                    MagnitudeY = Projectile.position.Y - offSet;
                }
                else
                {
                    MagnitudeY = Projectile.position.Y + offSet;
                }
                if (Projectile.velocity.X < 0)
                {
                    MagnitudeX = Projectile.position.X - offSet;
                }
                else
                {
                    MagnitudeX = Projectile.position.X + offSet;
                }
                Vector2 PosOffset = new Vector2(MagnitudeX, MagnitudeY);
                if (Length == 19)
                {
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), PosOffset, Vector2.Zero, ModContent.ProjectileType<SharpthornBody>(), 24, 0.07f, Projectile.whoAmI, Projectile.velocity.X, Projectile.velocity.Y);
                }
                else
                {
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), PosOffset, Vector2.Zero, ModContent.ProjectileType<SharpthornTop>(), 24, 0.07f, Projectile.whoAmI, Projectile.velocity.X, Projectile.velocity.Y);
                }
                

                     

            }

            base.OnSpawn(source);
        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 15;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 100;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.ArmorPenetration = 2;
        }
        int Timer = 0;
       
        public override void PostAI()
        {

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            Projectile.Kill();
            // The humber of projectiles that this gun will shoot.



            return base.OnTileCollide(oldVelocity);


        }



        public override void AI()
        {
           
        }

    }

    public class SharpthornBody : ModProjectile
    {
        int speed = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.rotation = new Vector2(Projectile.ai[0], Projectile.ai[1]).ToRotation();
            Projectile.velocity = new Vector2(0, 0);

        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 15;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 100;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.ArmorPenetration = 2;
        }
        int Timer = 0;

        public override void PostAI()
        {

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            Projectile.Kill();
            // The humber of projectiles that this gun will shoot.



            return base.OnTileCollide(oldVelocity);


        }



        public override void AI()
        {
            
        }

    }
    public class SharpthornTop : ModProjectile
    {
        int speed = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.rotation = new Vector2(Projectile.ai[0], Projectile.ai[1]).ToRotation();
            Projectile.velocity = new Vector2(0, 0);

        }
        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 15;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 100;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.ArmorPenetration = 2;
        }
        int Timer = 0;

        public override void PostAI()
        {

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            Projectile.Kill();
            // The humber of projectiles that this gun will shoot.



            return base.OnTileCollide(oldVelocity);


        }



        public override void AI()
        {

        }

    }

    public class Shell : ModProjectile
    {
        int speed = 4;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shell"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }
        public override void OnSpawn(IEntitySource source)
        {


            Projectile.position.X += Projectile.ai[0];

            Player player = FindClosestPlayer(750);

            Projectile.velocity = Projectile.DirectionTo(player.Center) * speed;



        }
        public Player FindClosestPlayer(float maxDetectDistance)
        {
            Player closestPlayer = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

           
            for (int k = 0; k < Main.maxPlayers; k++)
            {
                Player target = Main.player[k];
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                if (target.active && !target.dead)
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {

                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestPlayer = target;

                    }
                }

            }
            return closestPlayer;
        }
    

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 15;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 10000;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.ArmorPenetration = 2;
        }
        int Timer = 0;

        public override void PostAI()
        {

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            Projectile.Kill();
            // The humber of projectiles that this gun will shoot.



            return base.OnTileCollide(oldVelocity);


        }



        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }

}


















