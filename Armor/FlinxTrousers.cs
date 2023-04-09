using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TrueSoul.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FlinxTrousers : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flinx Fur Trousers");
            Tooltip.SetDefault("Very warm"
            +"\n10% increased movement speed"
            + "\n4% increased summon damage.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.wornArmor = true;
            Item.rare = 2;
            Item.width = 22;
            Item.height = 18;
            Item.value = 7700;
            Item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.GetDamage(DamageClass.Summon) += 0.04f;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.IceBlock, 3);
            recipe.AddIngredient(ItemID.FlinxFur, 5);
            recipe.AddIngredient(ItemID.Silk, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.GoldBar, 5);
            recipe2.AddIngredient(ItemID.IceBlock, 3);
            recipe2.AddIngredient(ItemID.FlinxFur, 5);
            recipe2.AddIngredient(ItemID.Silk, 8);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}
