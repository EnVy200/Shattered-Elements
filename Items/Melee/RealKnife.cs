using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Other;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Melee
{
    public class RealKnifeDevItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Real Knife"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("=)");
        }

        public override void SetDefaults()
        {
            Item.damage = 300;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 90;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 260;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<RealKnifeDevItemProjectile>();
            Item.shootSpeed = 21f;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }

       


        public override void AddRecipes()
        {

        }
    }
}