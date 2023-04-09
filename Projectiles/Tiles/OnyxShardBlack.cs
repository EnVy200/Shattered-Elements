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
	

	
		internal class OnyxShardBlackTile : ModTile
		{
			public override void SetStaticDefaults()
			{
				TileID.Sets.Ore[Type] = true;
			Color color = new Color(50, 50, 50);
			ModTranslation n = CreateMapEntryName();
			n.SetDefault("Onyx");
			AddMapEntry(color, n);
			Main.tileSolid[Type] = true;
				Main.tileBlockLight[Type] = false;
				Main.tileShine[Type] = 400;
				Main.tileShine2[Type] = true;
				Main.tileSpelunker[Type] = true;
				Main.tileOreFinderPriority[Type] = 60;
				Main.tileMerge[Type][ModContent.TileType<DeepStoneTile>()] = true;
			Main.tileMerge[Type][ModContent.TileType<OnyxShardTile>()] = true;
			Main.tileMerge[Type][TileID.Stone] = true;

		

				DustType = DustID.BoneTorch;
				ItemDrop = ModContent.ItemType<OnyxShardBlack>();
				HitSound = SoundID.Tink;

				MineResist = 1.7f;
				MinPick = 55;
			}
		}

		
}
