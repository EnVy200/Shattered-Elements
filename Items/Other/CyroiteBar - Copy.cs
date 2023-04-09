using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items.Placeables;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace TrueSoul.Items.Other
{
    public class StarlightBar : ModItem
    {
        public override void SetStaticDefaults()
        {

                DisplayName.SetDefault("Starlight Bar");
                Tooltip.SetDefault("This bar glows in your palm.");
          
        }

        public override void SetDefaults()
        {

            Item.value = 4250;
            Item.rare = 6;
            Item.maxStack = 999;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<StarlightOreItem>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}