using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LogicCorrupt.Content.Items
{
    internal class Ambarock : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = 400;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amber, 4);
            recipe.AddIngredient(ItemID.StoneBlock, 3);
            recipe.AddTile<Tile.MesaDeArtesano>();
            recipe.Register();
        }
    }
}
