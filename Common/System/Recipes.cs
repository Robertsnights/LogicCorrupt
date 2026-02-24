using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace LogicCorrupt.System
{
    public class Recipes : ModSystem
    {
        public static RecipeGroup Tables;
        public static RecipeGroup Chairs;
        public static RecipeGroup Torches;
        public override void AddRecipes()
        {
            RecipeGroup recipeGroup = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "demonsBar", new int[]
            {
                ItemID.demoniteBar,
                ItemID.crimtaneBar
            });
            RecipeGroup.RegisterGroup("Common:demonsBar", recipeGroup);
            Tables = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Table", new int[]
            {
                ItemID.WoodenTable,
                ItemID.BorealWoodTable,
                ItemID.RichMahoganyTable,
                ItemID.EbonwoodTable,
                ItemID.ShadewoodTable,
                ItemID.PalmWoodTable,
                ItemID.CactusTable,
                ItemID.FleshTable,
                ItemID.PearlwoodTable
            });
            RecipeGroup.RegisterGroup("Common:Tables", Tables);

            Chairs = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Chair", new int[]
            {
                ItemID.WoodenChair,
                ItemID.BorealWoodChair,
                ItemID.RichMahoganyChair,
                ItemID.EbonwoodChair,
                ItemID.ShadewoodChair,
                ItemID.PalmWoodChair,
                ItemID.CactusChair,
                ItemID.FleshChair,
                ItemID.PearlwoodChair
            });
            RecipeGroup.RegisterGroup("Common:Chairs", Chairs);

            Torches = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Torch", new int[]
            {
                ItemID.Torch,
                ItemID.BoneTorch,
                ItemID.CursedTorch,
                ItemID.IchorTorch
            });
            RecipeGroup.RegisterGroup("Common:Torches", Torches);
        }
    }
}