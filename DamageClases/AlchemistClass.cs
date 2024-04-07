using Terraria;
using Terraria.ModLoader;

namespace LogicCorrupt.DamageClases
{
    internal class AlchemistClass : DamageClass
    {
        

        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(
                damageInheritance: 0f,
                critChanceInheritance:0f,
                attackSpeedInheritance:0f,
                armorPenInheritance:0f,
                knockbackInheritance:0f
                );
        }
    }
}
