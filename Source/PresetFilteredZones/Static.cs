using System.Reflection;

using UnityEngine;
using Verse;

namespace PresetFilteredZones
{
    [StaticConstructorOnStartup]
    public static class Static
    {

        public static DesignationDef DesMealZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_MealZoneAdd");
        public static DesignationDef DesMedZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_MedZoneAdd");
        public static DesignationDef DesMeatZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_MeatZoneAdd");
        public static DesignationDef DesVegZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_VegZoneAdd");
        public static DesignationDef DesJoyZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_JoyZoneAdd");
        public static DesignationDef DesAnimalZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_AnimalZoneAdd");
        public static DesignationDef DesOutdoorZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_OutdoorZoneAdd");
        public static DesignationDef DesIndoorZone = DefDatabase<DesignationDef>.GetNamed("FZN_Designator_IndoorZoneAdd");

        public static string MealZoneDesc = "FZN_DescriptionMealZone".Translate();
        public static string MedZoneDesc = "FZN_DescriptionMedZone".Translate();
        public static string MeatZoneDesc = "FZN_DescriptionMeatZone".Translate();
        public static string VegZoneDesc = "FZN_DescriptionVegZone".Translate();
        public static string JoyZoneDesc = "FZN_DescriptionJoyZone".Translate();
        public static string AnimalZoneDesc = "FZN_DescriptionAnimalZone".Translate();
        public static string OutdoorZoneDesc = "FZN_DescriptionOutdoorZone".Translate();
        public static string IndoorZoneDesc = "FZN_DescriptionIndoorZone".Translate();
        //public static string GizmoShadeLabel =  "FZN_GizmoShadeLabel".Translate();
        //public static string GizmoShadeDesc =   "FZN_GizmoShadeDesc".Translate();

        public static Texture2D TexMealZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileMeal", true);
        public static Texture2D TexMedZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileMed", true);
        public static Texture2D TexMeatZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileMeat", true);
        public static Texture2D TexVegZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileVeg", true);
        public static Texture2D TexJoyZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileJoy", true);
        public static Texture2D TexAnimalZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileAnimal", true);
        public static Texture2D TexOutdoorZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileOutdoor", true);
        public static Texture2D TexIndoorZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileIndoor", true);

        //public static Texture2D GizmoShadeMeal =    ContentFinder<Texture2D>.Get("Cupro/UI/GizmoShadeMeal", true);
        //public static Texture2D GizmoShadeMed =     ContentFinder<Texture2D>.Get("Cupro/UI/GizmoShadeMed", true);
        //public static Texture2D GizmoShadeMeat =    ContentFinder<Texture2D>.Get("Cupro/UI/GizmoShadeMeat", true);
        //public static Texture2D GizmoShadeVeg =     ContentFinder<Texture2D>.Get("Cupro/UI/GizmoShadeVeg", true);
        //public static Texture2D GizmoShadeJoy =     ContentFinder<Texture2D>.Get("Cupro/UI/GizmoShadeJoy", true);
        //public static Texture2D GizmoShadeAnimal =  ContentFinder<Texture2D>.Get("Cupro/UI/GizmoShadeAnimal", true);


        public static string GetEnumDescription(PresetZoneType preset)
        {
            FieldInfo fieldInfo = preset.GetType().GetField(preset.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].description.Translate();
            }
            return preset.ToString().Translate();
        }

    }
}
