namespace PresetFilteredZones;

public class Designator_MedZoneAdd : Designator_PresetZoneAdd
{
    public Designator_MedZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Med;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.MedZoneDesc;
        icon = Static.TexMedZone;
        Def = Static.DesMedZone;
    }
}