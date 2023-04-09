using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using static Terraria.ModLoader.ModContent;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Melee;
using TrueSoul.Items.Ranged;

using TrueSoul.Items.Placeables;
using TrueSoul.Items.Other;
using TrueSoul.Projectiles.Minions;
using TrueSoul.Items.Whips;
using Terraria.WorldBuilding;
using Terraria.IO;
using System.Collections.Generic;
using TrueSoul.Items.Elementalist;

namespace ModGlobalNPCs
{

    public class ModGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // "denominator" is the chance of it appearing,
            // put down 
            if (npc.type == NPCID.GoblinSummoner)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShadowflameBar>(), 2, 1, 7));
            if (npc.type == NPCID.IceGolem)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 9));
            if (npc.type == NPCID.Retinazer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 3));
            if (npc.type == NPCID.TheDestroyer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 3));
            if (npc.type == NPCID.SkeletronPrime)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 3));

            if (npc.type == NPCID.MartianSaucer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MartianWhip>(), 5, 1, 1));
        }
    }
    public class ModGlobalItem : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.WoodenCrate)
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeaScepter>(), 50, 1, 1));
            if (item.type == ItemID.IronCrate)
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeaScepter>(), 20, 1, 1));
            if (item.type == ItemID.GoldenCrate)
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeaScepter>(), 10, 1, 1));

        }

    }


}  	
