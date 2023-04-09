using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Materials
{
    public class GlimmeringOnyxCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glimmering Onyx Core"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A powerful energy seems to possess this core.");
        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 999;
            Item.value = 2500;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {



        }





    }
}