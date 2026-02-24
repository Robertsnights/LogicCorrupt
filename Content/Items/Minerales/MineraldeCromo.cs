using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LogicCorrupt.Tiles;

namespace LogicCorrupt.Items.Minerales
{
    public class MineraldeCromo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mineral de Cromo");
            Tooltip.SetDefault("Un mineral brillante con un tono plateado, utilizado para crear objetos resistentes y decorativos.");
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
            Item.createTile = ModContent.TileType<Tiles.Cromo>();

        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TungstenOre, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}