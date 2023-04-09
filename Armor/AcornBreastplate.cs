using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueSoul.Items.Other;

namespace TrueSoul.Armor
{
	using Terraria;
	using Terraria.GameContent.Creative;
	using Terraria.ID;
	using Terraria.ModLoader;


	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class AcornBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Acorn Breastplate");

			Tooltip.SetDefault("A woodlike breastplate made of acorns, infused with a life crystal."
			+"\n+20 max health");


			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36; // Width of the item
			Item.height = 36; // Height of the item
			Item.sellPrice(silver: 2); // How many coins the item is worth
			Item.rare = ItemRarityID.Blue; // The rarity of the item
			Item.defense = 2; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 20; // Increase dealt damage for all weapon classes by 20%
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
			recipe.AddIngredient(ItemID.Acorn, 16);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddRecipeGroup("Wood", 35);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}

