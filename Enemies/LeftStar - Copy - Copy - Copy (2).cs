using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace TrueSoul.Enemies
{
    public class FlamingWall : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Wall"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //NPC.magic = true;
                        NPC.velocity.Y = 0f;
            NPC.velocity.X = 0f;
            NPC.width = 50;
            NPC.height = 20000;
            NPC.friendly = false;
            NPC.timeLeft = 2000;
            NPC.velocity.X = 1f;
            NPC.lifeMax = 1000;
            NPC.defense = 1;
            NPC.damage = 175;
            NPC.scale = 15;
            NPC.noGravity = true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            NPC.position.X += 800;
            NPC.position.Y += 900;
            base.OnSpawn(source);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
          
        }

        public override void AI()
        {
            NPC.velocity.X = -5f;







        }
    }
}