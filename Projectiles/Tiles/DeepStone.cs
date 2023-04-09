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
	

	
		internal class DeepStoneTile : ModTile
		{
			public override void SetStaticDefaults()
			{
			
			TileID.Sets.Ore[Type] = false;
			Color color = new Color(10, 10, 10);
			ModTranslation n = CreateMapEntryName();
			n.SetDefault("Shadestone");
			AddMapEntry(color, n);
			Main.tileSolid[Type] = true;
				Main.tileBlockLight[Type] = false;
				Main.tileShine2[Type] = true;
				Main.tileSpelunker[Type] = false;
				Main.tileOreFinderPriority[Type] = 60;
				Main.tileMerge[Type][TileID.Stone] = true;
				Main.tileMerge[Type][ModContent.TileType<OnyxShardTile>()] = true;
			Main.tileMerge[Type][ModContent.TileType<OnyxShardBlackTile>()] = true;
		

				DustType = DustID.Obsidian;
				ItemDrop = ModContent.ItemType<DeepStone>();
				HitSound = SoundID.Tink;

				MineResist = 1.2f;
				MinPick = 54;
			}
		}

		
}
