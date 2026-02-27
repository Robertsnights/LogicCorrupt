using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;

namespace LogicCorrupt.Biomes
{
    public class Corrocion : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        public override void SetStaticDefaults()
        {
            //DisplayName.setDefault("Corrocion");
            /*
            Main.bgCorruption = mod.GetTexture("Backgrounds/CorrocionBG");
            Main.bgCorruption2 = mod.GetTexture("Backgrounds/CorrocionBG");
            Main.bgCorruption3 = mod.GetTexture("Backgrounds/CorrocionBG");
            Main.bgCorruption4 = mod.GetTexture("Backgrounds/CorrocionBG");
            */
        }

        

        public override bool IsBiomeActive(Player player)
        {
            // Check if the player is in the Corrosive Biome
            int tileCount = 0;
            int startX = (int)(player.position.X / 16) - 50;
            int startY = (int)(player.position.Y / 16) - 50;
            for (int x = startX; x < startX + 100; x++)
            {
                for (int y = startY; y < startY + 100; y++)
                {
                    if (x >= 0 && x < Main.maxTilesX && y >= 0 && y < Main.maxTilesY)
                    {
                        Tile tile = Framing.GetTileSafely(x, y);
                        if (tile.HasTile && tile.TileType == ModContent.TileType<Tiles.Carne>())
                        {
                            tileCount++;
                        }
                    }
                }
            }

            return player.ZoneCorrupt && player.Center.Y > Main.worldSurface * 0.35f && tileCount > 10;
        }

        
    }
}