namespace PresetFilteredZones
{
    public class Designator_VegZoneAdd : Designator_PresetZoneAdd
    {
        public Designator_VegZoneAdd()
        {
            zoneTypeToPlace = typeof(Zone_PresetStockpile);
            preset = PresetZoneType.Veg;
            defaultLabel = Static.GetEnumDescription(preset);
            defaultDesc = Static.VegZoneDesc;
            icon = Static.TexVegZone;
            def = Static.DesVegZone;
        }
    }
}