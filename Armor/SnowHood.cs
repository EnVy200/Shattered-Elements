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
	public class SnowHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flinx Fur Cap");
			Tooltip.SetDefault("The puffy ball reminds you of.. um.. I have no clue."

			+ "\n9% increased summon damage."
			+ "\n4% increased summon critical chance.");

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
			return body.type == ItemID.FlinxFurCoat && legs.type == ModContent.ItemType <FlinxTrousers>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+44% whip length, +6% damage reduction, +2 defense, +1 minion slot.";


			player.endurance += 0.06f;
			player.whipRangeMultiplier += 0.44f;
			player.statDefense += 2;
			player.maxMinions += 1;



		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.09f;
			player.GetCritChance(DamageClass.Summon) += 0.04f;







		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FlinxFur, 12);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.IceBlock, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}