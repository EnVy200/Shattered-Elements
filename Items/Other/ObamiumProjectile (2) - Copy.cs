using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Other
{
    public class ShadowflameBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            
        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {



        }





    }
}