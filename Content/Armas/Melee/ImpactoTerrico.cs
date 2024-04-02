using LogicCorrupt.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using LogicCorrupt.DamageClases;

namespace LogicCorrupt.Content.Armas.Melee
{
    class ImpactoTerrico : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            //Item.DamageType = ModContent.GetInstance<TankDamageClass>();
            Item.DamageType = DamageClass.Melee;
            Item.width=36;
            Item.height = 36;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4;
            Item.value = 23000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<TerralitaDeSafiro>(7);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}