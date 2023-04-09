using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Melee
{
    public class TestSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gel Spear"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A spear made out of Gel, more effective than you'd think.");
        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = 3;
            Item.knockBack = 1;
            Item.value = 267;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 17);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}