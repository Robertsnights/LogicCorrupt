using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using LogicCorrupt.Content.Items.Minerales;
using static Terraria.ID.ContentSamples.CreativeHelper;


namespace LogicCorrupt.Tiles.Minerales
{
    internal class Nickel : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine[Type] = 900;
            Main.tileShine2[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 350;

            AddMapEntry(new Color(200, 200, 200), CreateMapEntryName());

            DustType = DustID.Iron;

            MineResist = 1.5f;
            MinPick = 80;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;

        }

        
    }
}