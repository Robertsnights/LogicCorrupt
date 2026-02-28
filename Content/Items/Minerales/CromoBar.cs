using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LogicCorrupt.Content.Items.Minerales;
using LogicCorrupt.Tiles;


namespace LogicCorrupt.Content.Items.Minerales
{
    public class CromoBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cromo Bar");
            // Tooltip.SetDefault("A bar made of Cromo, used for crafting.");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Green;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<MineraldeCromo>(4);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}