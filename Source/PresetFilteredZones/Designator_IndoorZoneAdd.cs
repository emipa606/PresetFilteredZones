namespace PresetFilteredZones;

public class Designator_IndoorZoneAdd : Designator_PresetZoneAdd
{
    public Designator_IndoorZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Indoor;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.IndoorZoneDesc;
        icon = Static.TexIndoorZone;
        Def = Static.DesIndoorZone;
    }
}