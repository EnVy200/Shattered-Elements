using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using TrueSoul.Projectiles.Tiles;
using IL.Terraria.WorldBuilding;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using TrueSoul.Items.Other;
using TrueSoul.Items.Placeables;

namespace TrueSoul.Items.Placeables
{
    internal class ResinantBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 40;
            ItemID.Sets.SortingPriorityMaterials[Type] = 91;
            DisplayName.SetDefault("Resonant Bar");
        }





        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = 6000;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;







            Item.createTile = ModContent.TileType<ResinantBarTile>();





        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DeepStone>(), 25);
            recipe.AddIngredient(ModContent.ItemType<OnyxShardBlack>(), 7);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }

}
