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
	

	
		internal class OnyxShardTile : ModTile
		{
			public override void SetStaticDefaults()
			{
				TileID.Sets.Ore[Type] = true;
			Color color = new Color(240, 240, 240);
			ModTranslation n = CreateMapEntryName();
			n.SetDefault("Purified Onyx");
			AddMapEntry(color, n);
			Main.tileSolid[Type] = true;
				Main.tileBlockLight[Type] = false;
				Main.tileShine[Type] = 300;
				Main.tileShine2[Type] = true;
				Main.tileSpelunker[Type] = true;
				Main.tileOreFinderPriority[Type] = 70;
				Main.tileMerge[Type][ModContent.TileType<DeepStoneTile>()] = true;
			Main.tileMerge[Type][ModContent.TileType<OnyxShardBlackTile>()] = true;
			Main.tileMerge[Type][TileID.Stone] = true;

		

				DustType = DustID.GemDiamond;
				ItemDrop = ModContent.ItemType<OnyxShard>();
				HitSound = SoundID.Tink;

				MineResist = 1.3f;
				MinPick = 55;
			}
			
		}

		
}
