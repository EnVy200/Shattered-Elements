using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace TrueSoul.Items.Melee
{
    public class MagmaticDemise : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Magmatic Demise");
            Tooltip.SetDefault("Has a chance to increase in XP every hit, if the XP reaches max, it increases damage, speed, and range.");
            ItemID.Sets.Yoyo[Item.type] = true;
        }

        public override void SetDefaults()
        {
        
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<MagmaticDemiseYoyoProjectile>();
            Item.shootSpeed = 6f;
            Item.noMelee = true;
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            Item.damage = 20 + (Main.LocalPlayer.GetModPlayer<Playe>().LevelMagmaYoyo - 1);
            base.ModifyWeaponDamage(player, ref damage);
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {



            base.ModifyTooltips(tooltips);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodYoyo);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }

    }
    public class MagmaticDemiseYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magmatic Demise");
          
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
        }
        public override void OnSpawn(IEntitySource source)
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 9 + (Main.LocalPlayer.GetModPlayer<Playe>().LevelMagmaYoyo * 2);
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 210 + (Main.LocalPlayer.GetModPlayer<Playe>().LevelMagmaYoyo * 20);
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 20 + (Main.LocalPlayer.GetModPlayer<Playe>().LevelMagmaYoyo * 5);
            base.OnSpawn(source);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int Randomizer = Main.rand.Next(1, 6);
            if (Randomizer == 2)
            {
                Main.LocalPlayer.GetModPlayer<Playe>().XPForMagmaYoyo += 1;
            }
           
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
