using Terraria;
using Terraria.ModLoader;

using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using LogicCorrupt.DamageClases;
using LogicCorrupt.Proyectiles.Alchemist;

namespace LogicCorrupt.Content.Armas.Alchemist
{
    internal class Reductora : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.mana = 10;
            Item.damage = 1;
            Item.DamageType = ModContent.GetInstance<AlchemistClass>();
            Item.noMelee = true;
            Item.consumable = false;
            Item.value = Item.buyPrice(0, 0, 14, 0);
            Item.knockBack = 2f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = Item.useTime = 30;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Gray;
            Item.shoot = ModContent.ProjectileType<Proyectile2>();
            Item.shootSpeed = 6f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int p = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddIngredient(ItemID.IronskinPotion, 1);
            recipe.AddIngredient(ItemID.LeadOre, 2);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}
