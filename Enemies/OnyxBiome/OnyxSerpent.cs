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
using System.IO;
using Terraria.GameContent.Bestiary;


namespace TrueSoul.Enemies.OnyxBiome
{
	internal class OnyxWormHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<OnyxWormBody>();

		public override int TailType => ModContent.NPCType<OnyxWormTail>();

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Serpent");

			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{ // Influences how the NPC looks in the Bestiary
				CustomTexturePath = "TrueSoul/Enemies/OnyxBiome/OnyxWorm_Bestiary", // If the NPC is multiple parts like a worm, a custom texture for the Bestiary is encouraged.
				//Position = new Vector2(40f, 24f),
				//PortraitPositionXOverride = 0f,
				//PortraitPositionYOverride = 12f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
		}

		public override void SetDefaults()
		{
			// Head is 10 defence, body 20, tail 30.
			NPC.CloneDefaults(NPCID.DiggerHead);
			NPC.aiStyle = -1;
			NPC.damage = 25;
			NPC.lifeMax = 70;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A digger that was unlucky enough to stumble upon the onyx caverns. It has been corrupted by the evil of the sacrificial altar, hence sacrificing it's soul for power. This digger has become one of the beasts within these dark caverns.")
			});
		}

		public override void Init()
		{
			// Set the segment variance
			// If you want the segment length to be constant, set these two properties to the same value
			MinSegmentLength = 30;
			MaxSegmentLength = 40;
			SegmentSeperation = 38;

			CommonWormInit(this);
		}

		// This method is invoked from ExampleWormHead, ExampleWormBody and ExampleWormTail
		internal static void CommonWormInit(Worm worm)
		{
			// These two properties handle the movement of the worm
			worm.MoveSpeed = 6f;
			worm.Acceleration = 0.059f;
		}

		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(attackCounter);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			attackCounter = reader.ReadInt32();
		}

		public override void AI()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				if (attackCounter > 0)
				{
					attackCounter--; // tick down the attack counter.
				}

				Player target = Main.player[NPC.target];
				// If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
				if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
				{
					Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

					int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ModContent.ProjectileType<OnyxianSpikeNoDirection>(), 5, 0, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 300;
					attackCounter = 500;
					NPC.netUpdate = true;
				}
			}
		}
	}

	internal class OnyxWormBody : WormBody
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Serpent");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.damage = 20;
			NPC.lifeMax = 70;
		}

		public override void Init()
		{
			OnyxWormHead.CommonWormInit(this);
		}
	}

	internal class OnyxWormTail : WormTail
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Serpent");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DiggerTail);
			NPC.aiStyle = -1;
			NPC.damage = 20;
			NPC.lifeMax = 70;
		}

		public override void Init()
		{
			OnyxWormHead.CommonWormInit(this);
		}
	}
}

