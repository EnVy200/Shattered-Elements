using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TrueSoul;
using TrueSoul.Items.Other;
namespace TrueSoul.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class AcornHardhat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Hardhat");
			Tooltip.SetDefault("A hard wooden shell made from acorns."

			+ "\n5% increased summon damage.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36; // Width of the item
			Item.height = 36; // Height of the item
			Item.value = 256; // How many coins the item is worth
			Item.rare = ItemRarityID.Blue; // The rarity of the item
			Item.defense = 1; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AcornBreastplate>() && legs.type == ModContent.ItemType<AcornGreaves>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+10% summon attack speed, +25% whip length, +1 defense, +1 minion slot.";



			player.whipRangeMultiplier += 0.25f;
			player.GetAttackSpeed(DamageClass.Summon) += 0.1f;
			player.statDefense += 1;
			player.maxMinions += 1;



		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.05f;







		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Acorn, 12);
			recipe.AddIngredient(ItemID.Cobweb, 15);
			recipe.AddRecipeGroup("Wood", 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}