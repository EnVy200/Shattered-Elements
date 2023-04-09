
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueSoul.Items.Whips
{
	public class AsteroidBeltWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Asteroid Belt");
			Tooltip.SetDefault("11 summon tag damage \n2% critical strike chance.");
		}



		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<AsteroidBeltWhipProjectile>(), 20, 2, 4);

			Item.shootSpeed = 4;
			Item.rare = 1;
			Item.DamageType = DamageClass.Summon;
			Item.damage = 29;
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
			recipe.AddIngredient(ItemID.Meteorite, 8);
			recipe.AddIngredient(ItemID.MeteoriteBar, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.


		// Makes the whip receive melee prefixes

	}
}
