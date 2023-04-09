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



        public class FlameBliss : ModItem
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Bliss of Flame");
                Tooltip.SetDefault("Shoots three flame blasts which the top and bottom of which curve away from the middle one. Bullets start weak and get stronger over time.");
                CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
                Item.staff[Item.type] = true;
            }
            public override void SetDefaults()
            {
                Item.height = 40;
                Item.width = 40;
                Item.damage = 13;
                Item.useStyle = 5;
                Item.useAnimation = 42;
                Item.useTime = 42;
                Item.knockBack = 3;
                Item.noMelee = true;
                Item.rare = ItemRarityID.Blue;
                Item.value = 9100;
                Item.DamageType = ModContent.GetInstance<FlameDamage>();
                Item.autoReuse = true;
                Item.shoot = ModContent.ProjectileType<FlameBlissProjectileFoward>();
                Item.shootSpeed = 13;
                Item.UseSound = SoundID.Item8;
                Item.mana = 5;

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
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<FlameBlissProjectileUpward>(), damage, knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<FlameBlissProjectileDownward>(), damage, knockback, player.whoAmI);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, 15f, 60f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, -15f, -60f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, -15f, 60f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, 15f, 60f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, -15f, 0f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, 15f, 0f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, 0f, 90f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, 0f, -90f, Alpha: 128, Scale: 1.2f);
            Dust.NewDustDirect(player.position, player.width, player.height, DustID.Torch, 15f, -32f, Alpha: 128, Scale: 1.2f);


            return true; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void AddRecipes()
            {
                Recipe recipe = CreateRecipe();
                recipe.AddRecipeGroup("IronBar", 21);
                recipe.AddIngredient(ModContent.ItemType<ResinantBar>(), 18);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                base.AddRecipes();
            }
        }
    
    }

