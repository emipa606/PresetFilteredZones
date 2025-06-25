namespace PresetFilteredZones;

public class Designator_MealZoneAdd : Designator_PresetZoneAdd
{
    public Designator_MealZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Meal;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.MealZoneDesc;
        icon = Static.TexMealZone;
        Def = Static.DesMealZone;
    }
}