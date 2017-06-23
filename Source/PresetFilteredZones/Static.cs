using System.Reflection;

using UnityEngine;
using Verse;

namespace PresetFilteredZones {
  [StaticConstructorOnStartup]
  public static class Static {

    public static DesignationDef DesMealZone =    DefDatabase<DesignationDef>.GetNamed("FZN_Designator_MealZoneAdd");
    public static DesignationDef DesMedZone =     DefDatabase<DesignationDef>.GetNamed("FZN_Designator_MedZoneAdd");
    public static DesignationDef DesMeatZone =    DefDatabase<DesignationDef>.GetNamed("FZN_Designator_MeatZoneAdd");
    public static DesignationDef DesVegZone =     DefDatabase<DesignationDef>.GetNamed("FZN_Designator_VegZoneAdd");
    public static DesignationDef DesJoyZone =     DefDatabase<DesignationDef>.GetNamed("FZN_Designator_JoyZoneAdd");
    public static DesignationDef DesAnimalZone =  DefDatabase<DesignationDef>.GetNamed("FZN_Designator_AnimalZoneAdd");

    public static string MealZoneDesc =   "FZN_DescriptionMealZone".Translate();
    public static string MedZoneDesc =    "FZN_DescriptionMedZone".Translate();
    public static string MeatZoneDesc =   "FZN_DescriptionMeatZone".Translate();
    public static string VegZoneDesc =    "FZN_DescriptionVegZone".Translate();
    public static string JoyZoneDesc =    "FZN_DescriptionJoyZone".Translate();
    public static string AnimalZoneDesc = "FZN_DescriptionAnimalZone".Translate();

    public static Texture2D TexMealZone =   ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileMeal",   true);
    public static Texture2D TexMedZone =    ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileMed",    true);
    public static Texture2D TexMeatZone =   ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileMeat",   true);
    public static Texture2D TexVegZone =    ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileVeg",    true);
    public static Texture2D TexJoyZone =    ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileJoy",    true);
    public static Texture2D TexAnimalZone = ContentFinder<Texture2D>.Get("Cupro/UI/ZoneCreate_StockpileAnimal", true);


    public static string GetEnumDescription(PresetZoneType preset) {
      FieldInfo fieldInfo = preset.GetType().GetField(preset.ToString());

      DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes != null && attributes.Length > 0) {
        return attributes[0].description;
      }
      return preset.ToString();
    }

  }
}
