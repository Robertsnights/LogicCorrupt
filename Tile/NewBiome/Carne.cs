using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;




namespace LogicCorrupt.Tiles.NewBiome
{
    internal class Carne : ModTile
    {
        public override void SetStaticDefaults()
        {
            //TileID.Sets.Stone = true;

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine2[Type] = true;

            AddMapEntry(new Color(200, 200, 200), CreateMapEntryName());

            MineResist = 2f;
            MinPick = 50;
            DustType = DustID.Blood;

            //ItemDrop = ModContent.ItemType<Carne>();
            HitSound = SoundID.Tink;
            TileID.Sets.Conversion.Stone[Type] = false;
            TileID.Sets.Conversion.Grass[Type] = false;
            TileID.Sets.Conversion.Sand[Type] = false;
            TileID.Sets.Corrupt[Type] = false;
            TileID.Sets.Crimson[Type] = false;
            TileID.Sets.Hallow[Type] = false;
            TileID.Sets.JungleSpecial[Type] = false;
            TileID.Sets.MushroomBiome[Type] = 0;
            

        }

        public override bool CanReplace(int i, int j, int tileTypeBeingPlaced)
        {
            if(tileTypeBeingPlaced == TileID.Ebonstone||
               tileTypeBeingPlaced == TileID.Crimstone||
               tileTypeBeingPlaced == TileID.Pearlstone)
               return false; // No permitir que el tile se reemplace a sí mismo
            
            return base.CanReplace(i, j, tileTypeBeingPlaced);
        }
    }
}
