using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria;
using Terraria.WorldBuilding;
using LogicCorrupt.Tiles.NewBiome;
using Terraria.GameContent.Generation;
using Terraria.IO;


namespace LogicCorrupt.System
{
    public class WorldSystem : ModSystem
    {
        
        public override void ModifyWorldGenTasks(List<GenPass> tasks,ref double totalWeight)
        {
            /*
            // Code to modify world generation tasks
            int index = tasks.FindIndex(genpass => genpass.Name.Equals("Corruption")||
            genpass.Name.Equals("Crimson"));
            
            if (index != -1)
            {
                tasks.Insert(index+1, new PassLegacy("Desatando el caos", GenerateBiome));
            }
            */
            int centerX = GenVars.rightBeachStart;
            int surfaceY=(int)Main.worldSurface;
            Main.spawnTileX = centerX;
            Main.spawnTileY = surfaceY;

        }
        /*
        
        private void GenerateBiome(GenerationProgress progress, GameConfiguration config)
        {

            // Code to generate custom biome
            progress.Message = "Generando el caos...";

            // Example: Generate a custom biome in the world
            // You can use WorldGen methods to place tiles, walls, and other features for your biome
            int centerX = GenVars.floatingIslandStyle == 0 ? GenVars.leftBeachEnd : GenVars.rightBeachStart;
            int surfaceY=(int)Main.worldSurface -2;
            
            int width =200;
            int height = 100;
            int blockCount=30;
            for (int i =0; i < blockCount; i++)
            {
                int x = centerX + WorldGen.genRand.Next(centerX - width, centerX + width);
                int y = surfaceY + WorldGen.genRand.Next(-height, 0);
            
                double strength = WorldGen.genRand.Next(30,60);
                int steps = WorldGen.genRand.Next(30,60);
                WorldGen.KillTile(x, y);
                WorldGen.TileRunner(x, y, strength, steps, ModContent.TileType<Carne>(), false, 0f, 0f, false, true);
            }
        }
        */
        public override void PostWorldGen()
        {
            // Code to execute after world generation is complete
            // You can perform additional setup or modifications to the world here
            
        }

        
    }
}