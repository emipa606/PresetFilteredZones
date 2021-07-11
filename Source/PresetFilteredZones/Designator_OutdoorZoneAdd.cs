namespace PresetFilteredZones
{
    public class Designator_OutdoorZoneAdd : Designator_PresetZoneAdd
    {
        public Designator_OutdoorZoneAdd()
        {
            zoneTypeToPlace = typeof(Zone_PresetStockpile);
            preset = PresetZoneType.Outdoor;
            defaultLabel = Static.GetEnumDescription(preset);
            defaultDesc = Static.OutdoorZoneDesc;
            icon = Static.TexOutdoorZone;
            def = Static.DesOutdoorZone;
        }
    }
}