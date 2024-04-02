using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using LogicCorrupt.DamageClases;
using LogicCorrupt.Content.Items;
using LogicCorrupt.Tile;

namespace LogicCorrupt.Content.Accesorios.Tank
{
    internal class AmuletoExtraño : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<TankDamageClass>() -= 5f;
            player.statDefense += 10;
            player.statLifeMax += 5;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 3);
            recipe.AddIngredient<Ambarock>(4);
            recipe.AddIngredient(ItemID.Leather, 2);
            recipe.AddTile<MesaDeArtesano>();
            recipe.Register();
        }
    }
}
