
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items.Placeables;

namespace TrueSoul.Items.Ranged
{
	public class OnyxianDarkforce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyxian Darkforce");
			Tooltip.SetDefault("Fires 2 arrows that change depending on the type of arrow you use. (Flaming, Wooden)");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// Common Properties
			Item.width = 40; // Hitbox width of the item.
			Item.height = 40; // Hitbox height of the item.
			Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 17; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 17; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.Item5; // The sound that this item plays when used.

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 10; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 6f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 8f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Arrow; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
				type = ModContent.ProjectileType<WeakOnyxArrow>();
			if (type == ProjectileID.FireArrow)
				type = ModContent.ProjectileType<FlamingOnyxArrow>();

			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 60f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

		}
		int otherDamage;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			
			if (type == ModContent.ProjectileType<FlamingOnyxArrow>())
            {
				otherDamage = 18;
            }
			if (type == ModContent.ProjectileType<WeakOnyxArrow>())
			{
				otherDamage = 16;
			}
			if (type != ModContent.ProjectileType<WeakOnyxArrow>() && type != ModContent.ProjectileType<FlamingOnyxArrow>())
            {
				otherDamage = damage;
            }
			const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

			for (int i = 0; i < NumProjectiles; i++)
			{
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, otherDamage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<OnyxShardBlack>(), 16);
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2f, -2f);
		}
	}

		public class WeakOnyxArrow : ModProjectile
		{
			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Weak Onyx Arrow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

			}

			public override void SetDefaults()
			{
				//Projectile.magic = true;
				Projectile.width = 40;
				Projectile.height = 40;
				Projectile.friendly = true;
				Projectile.hostile = false;
				Projectile.aiStyle = 1;
				Projectile.penetrate = 2;
				Projectile.timeLeft = 800;
				Projectile.light = 1f;
				Projectile.ignoreWater = false;
				Projectile.tileCollide = true;
			}
			int Timer = 0;
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(BuffID.Bleeding, 150, false);
			}
			public override void AI()
			{
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			}

		}
			public class FlamingOnyxArrow : ModProjectile
			{
				public override void SetStaticDefaults()
				{
					DisplayName.SetDefault("Weak Onyx Arrow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

				}

				public override void SetDefaults()
				{
					//Projectile.magic = true;
					Projectile.width = 40;
					Projectile.height = 40;
					Projectile.friendly = true;
					Projectile.hostile = false;
					Projectile.aiStyle = 1;
					Projectile.penetrate = 3;
					Projectile.timeLeft = 800;
					Projectile.light = 1f;
					Projectile.ignoreWater = false;
					Projectile.tileCollide = true;
				}
				int Timer = 0;
				public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
				{
					target.AddBuff(BuffID.ShadowFlame, 45, false);
					target.AddBuff(BuffID.Bleeding, 150, false);
				}
				public override void AI()
				{
					Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
				}

			}
	

}