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
		public class StarlightBreastplate : ModItem
		{
			public override void SetStaticDefaults()
			{
				base.SetStaticDefaults();
				DisplayName.SetDefault("Starlight Breastplate");
				Tooltip.SetDefault("A breastplate forged from the stars."
					+ "\n+6% damage");

				CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			}

			public override void SetDefaults()
			{
				Item.width = 36; // Width of the item
				Item.height = 36; // Height of the item
				Item.sellPrice(gold: 12); // How many coins the item is worth
				Item.rare = ItemRarityID.Red; // The rarity of the item
				Item.defense = 18; // The amount of defense the item will give when equipped
			}

			public override void UpdateEquip(Player player)
			{
			player.GetDamage(DamageClass.Generic) += 0.06f; // Increase dealt damage for all weapon classes by 20%
		    }

			// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
			public override void AddRecipes()
			{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<StarlightBar>(), 21);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		    }
		}
	}

