using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace LogicCorrupt.Content.Items
{
    internal class TerralitaDeSafiro : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 300;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ClayBlock, 2);
            recipe.AddIngredient(ItemID.Sapphire, 4);
            recipe.AddTile<Tile.MesaDeArtesano>();
            recipe.Register();
        }

    }
}
