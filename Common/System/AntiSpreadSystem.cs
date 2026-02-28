using Terraria;
using Terraria.ModLoader;

namespace LogicCorrupt.System
{
    public class AntiSpreadSystem : GlobalTile
    {
        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            // Evitar que los tiles de carne se propaguen
            if (type == ModContent.TileType<Tiles.NewBiome.Carne>())
            {
                return false; // No permitir que el tile sea destruido por propagación
            }
            return base.CanKillTile(i, j, type, ref blockDamaged);
        }
    }
}