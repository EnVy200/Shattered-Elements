using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Other;
using TrueSoul.DamageClasses;
using TrueSoul.Items.Placeables;


namespace TrueSoul.Accessories
{
    public class FlameCapsule : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Husk of Flame"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Increases flame damage by 12.5%.");
        }

        public override void SetDefaults()
        {
            Item.width = 60;
            Item.height = 60;
            Item.value = 10000;
            Item.rare = 3;
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<FlameDamage>() += 0.125f;
        }
           
        
           
        

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Torch, 18);
            recipe.AddIngredient(ItemID.LavaBucket, 2);
            recipe.AddIngredient(ModContent.ItemType<ResinantBar>(), 12);


        }
    }
}