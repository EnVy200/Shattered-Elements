using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TrueSoul.Items.Other;

namespace TrueSoul.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class AcornGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Greaves formed out of acorns and cobwebs (also wood)."
				+ "\n10% increased movement speed");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36; // Width of the item
			Item.height = 36; // Height of the item
            Item.value = 125; // How many coins the item is worth
			Item.rare = ItemRarityID.Blue; // The rarity of the item
			Item.defense = 1; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.10f; // Increase the movement speed of the player
		
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Acorn, 12);
			recipe.AddIngredient(ItemID.Cobweb, 20);
			recipe.AddRecipeGroup("Wood", 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}