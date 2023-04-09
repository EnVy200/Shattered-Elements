﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TrueSoul.Projectiles.Tiles
{
	public class ResinantBarTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileShine[Type] = 1100;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);

			Color color = new Color(71, 61, 61);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Resinant Bar");
			AddMapEntry(color, name);
		}

		public override bool Drop(int i, int j)
		{
			Tile t = Main.tile[i, j];
			int style = t.TileFrameX / 18;

			// It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
			if (style == 0)
			{
				Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeables.ResinantBar>());
			}

			return base.Drop(i, j);
		}
	}
}
