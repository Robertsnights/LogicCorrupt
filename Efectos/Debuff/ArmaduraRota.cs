using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace LogicCorrupt.Efectos.Debuff
{
    internal class ArmaduraRota : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 7;
            

        }
        public override void Update(Terraria.NPC npc, ref int buffIndex)
        {
            npc.defDefense -= 7;
            
        }
    }
}
