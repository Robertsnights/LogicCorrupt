using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ContentSamples.CreativeHelper;
using LogicCorrupt.Content.Items;

namespace LogicCorrupt.Tiles
{
    internal class Cromo : ModTile
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

            DustType = DustID.Tungsten;
            ItemGroup = ModContent.ItemType<Items.Minerales.MineraldeCromo>();
            MineResist = 1.5f;
            MinPick = 80;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;

        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail && Main.rand.NextBool(10))
            {
                Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Minerales.MineraldeCromo>());
            }
        }
    }
}