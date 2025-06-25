namespace PresetFilteredZones;

public class Designator_MeatZoneAdd : Designator_PresetZoneAdd
{
    public Designator_MeatZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Meat;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.MeatZoneDesc;
        icon = Static.TexMeatZone;
        Def = Static.DesMeatZone;
    }
}