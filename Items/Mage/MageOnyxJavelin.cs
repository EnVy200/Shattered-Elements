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

namespace TrueSoul.Items.Mage
{



        public class MageOnyxJavelin : ModItem
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Onyx Javelin");
                Tooltip.SetDefault("Fires a low gravity javelin towards your cursor. This projectile has infinite pierce.");
                CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
                Item.staff[Item.type] = true;
            }
            public override void SetDefaults()
            {
                Item.height = 40;
                Item.width = 40;
                Item.damage = 16;
                Item.useStyle = 5;
                Item.useAnimation = 19;
                Item.useTime = 19;
                Item.knockBack = 3;
                Item.noMelee = true;
                Item.rare = ItemRarityID.Blue;
                Item.value = 9100;
                Item.DamageType = DamageClass.Magic;
                Item.autoReuse = true;
                Item.shoot = ModContent.ProjectileType<OnyxJavProject>();
                Item.shootSpeed = 9;
                Item.UseSound = SoundID.Item8;
                Item.mana = 7;

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
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));

                    // Decrease velocity randomly for nicer visuals.
                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    // Create a projectile.
                    Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                }




                Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
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
    public class OnyxJavProject : ModProjectile
    {
        float speed;

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.velocity = Projectile.DirectionTo(Main.MouseWorld) * 15;
            base.OnSpawn(source);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Javelin"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[Projectile.type] = 1;
        }


        public override void SetDefaults()
        {
            //Projectile.magic = true;
            speed = 0.6f;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 999999999;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 1200;

            Projectile.light = 0.1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;


        }
        int Timer = 0;


        public override void AI()
        {

     
            Projectile.velocity.Y += (0.1f * speed);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;




            base.AI();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 dir = Vector2.Zero;
            for (int i = 0; i < 15; i++)
            {
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GemDiamond, dir.X, dir.Y, Alpha: 128, Scale: 1.2f);
                dir = dir.RotatedBy(MathHelper.ToRadians(24));
            }
            
            return base.OnTileCollide(oldVelocity);
        }





    }


}

