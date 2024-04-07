using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LogicCorrupt.DamageClases;
using LogicCorrupt.Content.Items;

namespace LogicCorrupt.Content.Armas.Tank
{
    internal class RompeMuelas : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = ModContent.GetInstance<TankDamageClass>();
            
            Item.width = 42;
            Item.height = 42;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 20;
            Item.value = 23000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<Ambarock>(5);
            recipe.AddIngredient(ItemID.GoldBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
