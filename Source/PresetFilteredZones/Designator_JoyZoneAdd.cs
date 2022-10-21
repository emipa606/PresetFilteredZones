namespace PresetFilteredZones;

public class Designator_JoyZoneAdd : Designator_PresetZoneAdd
{
    public Designator_JoyZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        preset = PresetZoneType.Joy;
        defaultLabel = Static.GetEnumDescription(preset);
        defaultDesc = Static.JoyZoneDesc;
        icon = Static.TexJoyZone;
        def = Static.DesJoyZone;
    }
}