namespace PresetFilteredZones;

public class Designator_OutdoorZoneAdd : Designator_PresetZoneAdd
{
    public Designator_OutdoorZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Outdoor;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.OutdoorZoneDesc;
        icon = Static.TexOutdoorZone;
        Def = Static.DesOutdoorZone;
    }
}