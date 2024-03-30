using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LogicCorrupt.Content.Armas.Melee
{
    class ImpactoTerrico : ModItem
    {
        public override void SetDefaults()
        {
            Item.Damage = 45;
            Item.DamageType = DamageClass.Melee;
            Item.Width=36;

        }
    }
}