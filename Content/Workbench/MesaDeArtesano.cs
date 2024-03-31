using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace LogicCorrupt.Content.Workbench
{
    public class MesaDeArtesano : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 41;
            Item.height = 33;

            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;
            Item.useTurn = true;

            Item.maxStack = 999;
            Item.consumable = true;

            Item.createTile=ModContent.TileType<Tile.MesaDeArtesano>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddIngredient(ItemID.Lens, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}