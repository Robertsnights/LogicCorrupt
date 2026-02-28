using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace LogicCorrupt.Content.Items.Minerales
{
    public class MineraldeNickel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mineral de Nickel");
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
            

        }
        /*
        public override void OnCreated(ItemCreationContext context)
        {
            if(context is RecipeItemCreationContext) // Verifica si el contexto es de consumo de item
            {
                // Lógica adicional al consumir el mineral, si es necesario.
                Player player = Main.LocalPlayer; // Obtén el jugador local
                player.QuickSpawnItem(ModContent.ItemType<MineraldeNickel>(), 2); // Esto hará que el jugador reciba una barra de Nickel al consumir el mineral.
                player.QuickSpawnItem(player.GetSource_Misc("Mineral de Nickel obtenido"),ItemID.IronBar,1); // Esto hará que el jugador reciba una barra de Hierro al consumir el mineral.
            }
        }
        */
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}