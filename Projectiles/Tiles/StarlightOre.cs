using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using TrueSoul.Items.Placeables;


namespace TrueSoul.Projectiles.Tiles
{
	using Microsoft.Xna.Framework;
	using System.Collections.Generic;
	using Terraria;
	using Terraria.ID;
	using Terraria.IO;
	using Terraria.ModLoader;
	using Terraria.WorldBuilding;
	

	
		internal class StarlightOre : ModTile
		{
			public override void SetStaticDefaults()
			{
				TileID.Sets.Ore[Type] = true;

				Main.tileSolid[Type] = true;
				Main.tileBlockLight[Type] = true;
				Main.tileShine[Type] = 50;
				Main.tileShine2[Type] = true;
				Main.tileSpelunker[Type] = true;
				Main.tileOreFinderPriority[Type] = 600;

				AddMapEntry(new Color(175, 229, 255), CreateMapEntryName());

				DustType = DustID.GemDiamond;
				ItemDrop = ModContent.ItemType<StarlightOreItem>();
				HitSound = SoundID.Tink;

				MineResist = 2.5f;
				MinPick = 150;
			}
		}

		public class StarlightOreSystem : ModSystem
		{
			public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
			{
				// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

				// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
				// First, we find out which step "Shinies" is.
				int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

				if (ShiniesIndex != -1)
				{
					// Next, we insert our pass directly after the original "Shinies" pass.
					// ExampleOrePass is a class seen bellow
					tasks.Insert(ShiniesIndex + 1, new StarlightOrePass("TrueSoul Ores", 237.4298f));
				}
			}
		}

		public class StarlightOrePass : GenPass
		{
			public StarlightOrePass(string name, float loadWeight) : base(name, loadWeight)
			{
			}

			protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
			{
				// progress.Message is the message shown to the user while the following code is running.
				// Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes.
				progress.Message = "Generating some stars in the ground.";

				// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
				// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.

			}
		}
	


}
