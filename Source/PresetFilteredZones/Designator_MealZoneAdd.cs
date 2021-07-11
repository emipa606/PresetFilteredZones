namespace PresetFilteredZones
{
    public class Designator_MealZoneAdd : Designator_PresetZoneAdd
    {
        public Designator_MealZoneAdd()
        {
            zoneTypeToPlace = typeof(Zone_PresetStockpile);
            preset = PresetZoneType.Meal;
            defaultLabel = Static.GetEnumDescription(preset);
            defaultDesc = Static.MealZoneDesc;
            icon = Static.TexMealZone;
            def = Static.DesMealZone;
        }
    }
}