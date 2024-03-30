using Terraria;
using Terraria.ModLoader;

using Terraria.ID;
using Terraria.Localization;


namespace LogicCorrupt.NPC.Enemigos.Bosses
{
    internal class KingOfBlood : ModNPC
    {
        /*
        public override void SetStaticDefault(){
            this.HideFromBestiary();
            Main.npcFrameCount[NPC.type]=2;
        }
*/
        public override void SetDefaults(){
            NPC.aiStyle=NPCAIStyleID.Slime;
            
            NPC.width=40;
            NPC.height =30;
            NPC.defense = 10;

            NPC.lifeMax=20000;
            NPC.knockBackResist=0f;
            NPC.Opacity =0.8f;
            NPC.lavaImmune=false;
            NPC.noGravity=false;
            NPC.noTileCollide=false;
            NPC.canGhostHeal=false;
            NPC.HitSound=SoundID.NPCHit1;
            NPC.DeathSound=SoundID.NPCDeath1;


        }
    }
}