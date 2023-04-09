
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueSoul.Items.Whips
{
	public class MartianWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Martian Whip");
			Tooltip.SetDefault("12 summon tag damage \n13% critical strike chance.");
		}



		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<MartianWhipProjectile>(), 20, 2, 4);

			Item.shootSpeed = 4;
			Item.rare = 1;
			Item.DamageType = DamageClass.Summon;
			Item.damage = 54;
			Item.value = 300;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 2;
			Item.crit = 13;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.scale = 0.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MartianConduitPlating, 8);
			recipe.AddIngredient(ItemID.SoulofFright, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.


		// Makes the whip receive melee prefixes

	}
}
