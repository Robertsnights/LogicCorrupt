using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Content.Armas.Melee
{
    internal class SublimacionFerrea : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage=60;
            Item.DamageType=DamageClass.Melee;
            Item.height=36;
            Item.width=36;
            Item.useTime=20;
            Item.useAnimation=20;
            Item.useStyle=ItemUseStyleID.Swing;
            Item.knockBack=5;
            Item.value=33000;
            Item.rare=ItemRarityID.Green;
            Item.UseSound=SoundID.Item1;
            Item.autoReuse=true;
            Item.useTurn=true;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}