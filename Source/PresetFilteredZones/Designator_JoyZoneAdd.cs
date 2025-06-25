namespace PresetFilteredZones;

public class Designator_JoyZoneAdd : Designator_PresetZoneAdd
{
    public Designator_JoyZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Joy;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.JoyZoneDesc;
        icon = Static.TexJoyZone;
        Def = Static.DesJoyZone;
    }
}