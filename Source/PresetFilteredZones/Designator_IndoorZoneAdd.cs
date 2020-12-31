
namespace PresetFilteredZones
{

    public class Designator_IndoorZoneAdd : Designator_PresetZoneAdd
    {

        public Designator_IndoorZoneAdd()
        {
            zoneTypeToPlace = typeof(Zone_PresetStockpile);
            preset = PresetZoneType.Indoor;
            defaultLabel = Static.GetEnumDescription(preset);
            defaultDesc = Static.IndoorZoneDesc;
            icon = Static.TexIndoorZone;
            def = Static.DesIndoorZone;
        }
    }
}
