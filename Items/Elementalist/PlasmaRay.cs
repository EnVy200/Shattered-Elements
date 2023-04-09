using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using TrueSoul.DamageClasses;
using Terraria.DataStructures;
using TrueSoul.Dusts;
using TrueSoul.Items.Placeables;

namespace TrueSoul.Items.Elementalist
{



        public class PlasmaRay : ModItem
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Plasma Ray");
                Tooltip.SetDefault("Fires a plasma blast that bounces from enemy to enemy.");
                CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
                Item.staff[Item.type] = true;
            }
            public override void SetDefaults()
            {
                Item.height = 68;
                Item.width = 68;
                Item.damage = 21;
                Item.useStyle = 5;
                Item.useAnimation = 33;
                Item.useTime = 66;
                Item.knockBack = 1;
                Item.noMelee = true;
                Item.rare = ItemRarityID.Blue;
                Item.value = 10000;
                Item.DamageType = ModContent.GetInstance<ElectricDamage>();
                Item.autoReuse = true;
                Item.shoot = ModContent.ProjectileType<PlasmaRayProjectile>();
                Item.shootSpeed = 12;
                Item.UseSound = SoundID.Item8;
                Item.mana = 10;

            }
            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
            {
                Vector2 offset = Vector2.Normalize(velocity) * 64;
                position += offset;
            }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 0; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
       


            return true; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void AddRecipes()
            {
                Recipe recipe = CreateRecipe();
                recipe.AddRecipeGroup("IronBar", 21);
                recipe.AddIngredient(ModContent.ItemType<ResinantBar>(), 11);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                base.AddRecipes();
            }
        }
    
    }

