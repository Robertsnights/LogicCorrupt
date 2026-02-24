using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using LogicCorrupt.Tiles;
using Terraria.IO;

namespace LogicCorrupt.System
{
    public class BlackOreGenPass : GenPass
    {
        public BlackOreGenPass() : base("Black Ore Generation", 100f)
        {
            
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generando Ores exoticos...";

            for (int i = 0; i < (int)(Main.maxTilesX * Main.maxTilesY * 0.0001); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 200);

                if (WorldGen.TileEmpty(x, y))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 5), ModContent.TileType<Cromo>());
                }
                if(WorldGen.TileEmpty(x, y))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(4, 7), ModContent.TileType<Nickel>());
                }
            }
        }
    }
}