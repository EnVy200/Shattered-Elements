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
	public class StarlightHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A helmet forged from heavenly ore."

			+"\n13% increased crit chance.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36; // Width of the item
			Item.height = 36; // Height of the item
			Item.sellPrice(gold: 6); // How many coins the item is worth
			Item.rare = ItemRarityID.Red; // The rarity of the item
			Item.defense = 21; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<StarlightBreastplate>() && legs.type == ModContent.ItemType<StarlightLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+22% damage";



			player.GetDamage(DamageClass.Generic) += 0.22f; // Increase dealt damage for all weapon classes by 20%



		}
		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Generic) += 0.13f;

 
				
					
			    

			
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