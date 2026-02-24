using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.IO;

namespace LogicCorrupt.System
{
    public class BiomGenerate : GenPass
    {
        public BiomGenerate() : base("Biom Generate", 100f)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generando Biomas...";

            // Code to generate biomes
            
        }
    }
}