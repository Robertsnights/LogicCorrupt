using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.Localization;

namespace LogicCorrupt.Tiles.Minerales
{
    internal class MineralSolid : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileShine[Type] = 1100;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Cromo"));
            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Nickel"));

        }
/*
        public override bool Drop(int x, int y)
        {
            Tile t = Main.tile[x, y];
            int style = t.TileFrameX / 18;

            switch (style)
            {
                case 0:
                    Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, 16, ModContent.ItemType<Content.Items.Minerales.CromoBar>());
                    break;
                case 1:
                    Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, 16, ModContent.ItemType<Content.Items.Minerales.NickelBar>());
                    //para añadir mas
                    break;
                case 2:
                    //mas metales
                    break;
            }

            return base.Drop(x, y);
        }
*/
    }
    
}
