
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueSoul.Items.Whips
{
	public class Thundercrack : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Thundercrack");
			Tooltip.SetDefault("9 summon tag damage \n15% critical strike chance.");
		}


		
		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<ThundercrackWhipProjectile>(), 20, 2, 4);

			Item.shootSpeed = 4;
			Item.rare = 1;
			Item.DamageType = DamageClass.Summon;
			Item.damage = 21;
			Item.value = 300;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 2;
			Item.crit = 2;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.scale = 0.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Chain, 8);
			recipe.AddIngredient(ItemID.Starfury, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.


		// Makes the whip receive melee prefixes

	}
}
