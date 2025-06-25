namespace PresetFilteredZones;

public class Designator_VegZoneAdd : Designator_PresetZoneAdd
{
    public Designator_VegZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Veg;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.VegZoneDesc;
        icon = Static.TexVegZone;
        Def = Static.DesVegZone;
    }
}