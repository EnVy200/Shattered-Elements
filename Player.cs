
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using TrueSoul.Enemies;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework.Graphics;

namespace TrueSoul
{
    public class Playe : ModPlayer
    {
        public int ClickAOE = 1;
        public int ClickAOEAdd = 0;
        public int Clicks = 0;
        public bool IsAstralMinionBuffActive = false;
        public bool slimeShoes = false;
        public int LevelMagmaYoyo = 1;
        public int XPForMagmaYoyo = 0;
        public float XPMaxForMagmaYoyo = 25;
        public bool IsMagmayoyoActive = false;
        public NPC target1soul;
        public NPC target2soul;
        Vector2 from;
        Vector2 to;
        Texture2D chainTexture = (Texture2D)ModContent.Request<Texture2D>("TrueSoul/Items/Generic/SoullinkChain");

        void MakeChain()
        {
            float dist = Vector2.Distance(from, to);
            float size = chainTexture.Width;
            Vector2 step = Vector2.Normalize((from - to));
            Vector2 origin = chainTexture.Size() / 2;

            float angle = (from - to).ToRotation();
            for (float i = 0; i < dist; i += size)
            {
                Vector2 pos = from + step * i;
                Main.EntitySpriteDraw(chainTexture, pos - Main.screenPosition, null, Color.White, angle, origin, 1, SpriteEffects.None, 0);
            }
        }

        public override void SaveData(TagCompound tag)
        {

            tag["MagmaYoyoXpMaxSet"] = XPMaxForMagmaYoyo;
            tag["XPMagmaYoyo"] = XPForMagmaYoyo; // save
            tag["MagmaYoyoLevelSet"] = LevelMagmaYoyo; // save

        }

        public override void LoadData(TagCompound tag)
        {
            XPForMagmaYoyo = tag.GetInt("XPMagmaYoyo"); // load
            XPMaxForMagmaYoyo = tag.GetFloat("MagmaYoyoXpMaxSet"); // load
            LevelMagmaYoyo = tag.GetInt("MagmaYoyoLevelSet"); // load

        }

        public override void PostUpdate()
        {
            if (target1soul != null && target2soul != null)
            {
                from = target1soul.position;
                to = target2soul.position;
                MakeChain();
            }    
            
           if (target1soul.life <= 0)
            {
                target1soul.life = -5;
                target2soul.life = -5;
                target1soul = null;
                target2soul = null;
            }
            if (target2soul.life <= 0)
            {
                target1soul.life = -5;
                target2soul.life = -5;
                target1soul = null;
                target2soul = null;
            }

            if  (XPForMagmaYoyo > XPMaxForMagmaYoyo)
            {
                LevelMagmaYoyo += 1;
                XPMaxForMagmaYoyo *= 1.12f;
                XPForMagmaYoyo = 0;
            }
            if (Player.velocity.X != 0 && slimeShoes)
            {
                if (Player.velocity.Y == 0f)
                {
                    int dust = Dust.NewDust(Player.position + new Vector2(0, Player.height - 4), Player.width, 4, 16, 0f, 0f, 0, Colors.RarityBlue, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0;
                }
            }
            if (NPC.AnyNPCs(ModContent.NPCType<ArdentPhase1>()))
                {
                Player.statDefense += 170;
                Player.lifeRegen = 4;
   

            }


        }
        
        public override void ResetEffects()
        {
            slimeShoes = false;
        }
    }
}