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
	public class StarlightLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Leggings from the heavens."
				+ "\n85% increased movement speed"
				+ "\n8% increased ranged damage.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36; // Width of the item
			Item.height = 36; // Height of the item
			Item.sellPrice(gold: 5); // How many coins the item is worth
			Item.rare = ItemRarityID.Red; // The rarity of the item
			Item.defense = 16; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.85f; // Increase the movement speed of the player
			player.GetDamage(DamageClass.Ranged) += 0.08f; // Increase dealt damage for all weapon classes by 20%
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<StarlightBar>(), 22);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}