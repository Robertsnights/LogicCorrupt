using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria;
using Terraria.WorldBuilding;
using LogicCorrupt.Tiles;
using Terraria.GameContent.Generation;


namespace LogicCorrupt.System
{
    public class WorldSystem : ModSystem
    {
        
        public override void ModifyWorldGenTasks(List<GenPass> tasks,ref double totalWeight)
        {
            // Code to modify world generation tasks
            int index = tasks.FindIndex(genpass => genpass.Name.Equals("Corruption")||
            genpass.Name.Equals("Crimson"));
            /*
            if (index != -1)
            {
                tasks.Insert(index+1, new PassLegacy("Desatando el caos", GenerateBiome));
            }
            */
        }

        private void GenerateBiome(GenerationProgress progress)
        {
            // Code to generate custom biome
            progress.Message = "Generando el caos...";

            // Example: Generate a custom biome in the world
            // You can use WorldGen methods to place tiles, walls, and other features for your biome
            int centerX = Main.maxTilesX / 2;
            int surfaceY=(int)Main.worldSurface;
            
            int width =200;
            int height = 100;
            
            for (int x = centerX; x < centerX + width; x++)
            {
                for (int y = surfaceY - height; y < surfaceY; y++)
                {
                    // Example: Place a custom tile for the biome
                    WorldGen.KillTile(x, y);
                    WorldGen.PlaceTile(x, y, ModContent.TileType<Carne>(),true,true);
                }
            }
        }
    }
}