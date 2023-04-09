using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using TrueSoul.Projectiles.Tiles;
using IL.Terraria.WorldBuilding;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using TrueSoul.Items.Other;

namespace TrueSoul.Items.Placeables
{
    internal class DeepStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 40;
            ItemID.Sets.SortingPriorityMaterials[Type] = 100;
            DisplayName.SetDefault("Shadestone");
        }


        


        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = 45;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.createTile = ModContent.TileType<DeepStoneTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.AddIngredient(ModContent.ItemType<OnyxShardBlack>(), 1);
            recipe.AddTile(ModContent.TileType<SacrificalAltar>());
            recipe.Register();
            recipe.AddCondition(Recipe.Condition.NearWater);
        }
    }

}
	