namespace PresetFilteredZones;

public class Designator_MeatZoneAdd : Designator_PresetZoneAdd
{
    public Designator_MeatZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        preset = PresetZoneType.Meat;
        defaultLabel = Static.GetEnumDescription(preset);
        defaultDesc = Static.MeatZoneDesc;
        icon = Static.TexMeatZone;
        def = Static.DesMeatZone;
    }
}