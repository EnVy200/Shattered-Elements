using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items.Placeables;
using TrueSoul.Projectiles.Tiles;

namespace TrueSoul.Items.Other
{
    public class StarlightOreSummonItem : ModItem
    {
        int SayText = 2;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Crown Of Stars"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Consume this to summon Starlight Ore.");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = 4;
            Item.knockBack = 1;
            Item.value = 267;
            Item.rare = 1;
            Item.UseSound = SoundID.Item2;
            Item.autoReuse = false;
            Item.consumable = true;
            Item.noMelee = true;
            
        }
        public override void OnConsumeItem(Player player)
        {
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                // The inside of this for loop corresponds to one single splotch of our Ore.
                // First, we randomly choose any coordinate in the world by choosing a random x and y value.
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place.
                // Feel free to experiment with strength and step to see the shape they generate.
                WorldGen.OreRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 3), (ushort)ModContent.TileType<StarlightOre>());

                // Alternately, we could check the tile already present in the coordinate we are interested.
                // Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
                // Tile tile = Framing.GetTileSafely(x, y);
                // if (tile.active() && tile.type == TileID.SnowBlock)
                // {
                // 	WorldGen.TileRunner(.....);
                // }
                if (SayText == 2)
                {
                    Main.NewText("The stars have fallen from the heavens and have pierced into the ground.", 150, 250, 150);
                    SayText = 1;
                }
                
                
            }
            base.OnConsumeItem(player);
        }
        public override bool? UseItem(Player player)
        {
           
            
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

        }
    }
}