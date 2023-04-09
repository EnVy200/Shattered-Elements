using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Placeables;
using TrueSoul.Items.Materials;

namespace TrueSoul.Projectiles.Tiles
{
	internal class SacrificalAltar : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileFrameImportant[Type] = true;

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true; // Optional, if you add more placeStyles for the item 
			TileObjectData.addTile(Type);

			// Etc
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Onyx Altar"); //Vanilla has no lang entry for this
			AddMapEntry(new Color(200, 200, 200), name);
		}
        public override void MouseOver(int i, int j)
        {
			
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<GlimmeringOnyxCore>()))
			{
				Main.LocalPlayer.cursorItemIconEnabled = true;
				Main.LocalPlayer.cursorItemIconID = ModContent.ItemType<GlimmeringOnyxCore>();
			}
			


			base.MouseOver(i, j);
        }
        public override bool RightClick(int i, int j)
        {
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<GlimmeringOnyxCore>()))
            {

            }

			return base.RightClick(i, j);
        }

        public override bool CreateDust(int i, int j, ref int type)
		{
			return false;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<OnyxAltar>(), 1);
		}
	}
}
