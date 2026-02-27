using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LogicCorrupt.Tiles;
using LogicCorrupt.Content.Items.Minerales;
using Terraria.DataStructures;

namespace LogicCorrupt.Content.Items.Minerales
{
    public class MineraldeCromo : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mineral de Cromo");
            // Tooltip.SetDefault("Un mineral brillante con un tono plateado, utilizado para crear objetos resistentes y decorativos.");
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 8;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(copper: 50);
            Item.rare = ItemRarityID.White;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tile.Minerales.Cromo>();

        }
        /*
        public override void OnCreated(ItemCreationContext context)
        {
            // Aquí puedes agregar cualquier lógica adicional que quieras ejecutar cuando se consuma el mineral, si es necesario.
            if (context is RecipeItemCreationContext) // Verifica si el contexto es de consumo de item
            {
                // Lógica adicional al consumir el mineral, si es necesario.
                Player player = Main.LocalPlayer; // Obtén el jugador local
                player.QuickSpawnItem(ModContent.ItemType<MineraldeCromo>(), 2); // Esto hará que el jugador reciba una barra de Cromo al consumir el mineral.
                player.QuickSpawnItem(player.GetSource_Misc("Mineral de Cromo obtenido"),ItemID.TungstenBar,1); // Esto hará que el jugador reciba una barra de Cromo al consumir el mineral.
            }

        }
*/
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TungstenOre, 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}