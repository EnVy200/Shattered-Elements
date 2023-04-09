using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace TrueSoul.Items.Whips
{
	public class StaticDebuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Static");
			Description.SetDefault("Removes 8 defense, and adds 5 attack.");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
		}
		int LifeTickDown = 0;
		int DeathRandomizer = 0;
		public override void Update(NPC NPC, ref int buffIndex)
		{
			Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<ZappedDust>(), 2f, 2f, Alpha: 128, Scale: 1.2f);

			if (NPC.boss == true)
            {
				NPC.defense -= 9;
				NPC.damage += 7;
			}
			else
            {
				NPC.defense -= 8;
				NPC.damage += 5;
				
			}
		}
	}
}


