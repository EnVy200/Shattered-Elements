using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace TrueSoul.Items.Whips
{
	public class ZappedDebuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zapped");
			Description.SetDefault("Stuns the enemy.");

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
				NPC.defense -= 1;
			}
			else
            {
				NPC.velocity.X = 0;
				NPC.velocity.Y = 0;
			}
		}
	}
}


