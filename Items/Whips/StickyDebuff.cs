using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace TrueSoul.Items.Whips
{
	public class StickyDebuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sticky");
			Description.SetDefault("Freezes the enemy in place, reduces damage by 3, and reduces defense by 5.");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
		}
		int LifeTickDown = 0;
		int DeathRandomizer = 0;
		public override void Update(NPC npc, ref int buffIndex)
		{

			if (npc.boss == true)
            {
				npc.defense -= 2;
				npc.velocity.X = npc.velocity.X * 0.98f;
				npc.velocity.Y = npc.velocity.Y * 0.98f;
				npc.damage -= 2;
			}
			else
            {
				npc.velocity.X = npc.velocity.X * 0.8f;
				npc.velocity.Y = npc.velocity.Y * 0.8f;
				npc.defense -= 5;
				npc.damage -= 3;
				
			}
		}
	}
}


