using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueSoul
{
    public class Buffed : GlobalItem
    {




        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.EnchantedSword) item.shootSpeed = 5;
            if (item.type == ItemID.EnchantedSword) item.damage = 71;
            if (item.type == ItemID.Zenith) item.damage = 300;
            if (item.type == ItemID.LastPrism) item.damage = 60;
        }



    }
}
