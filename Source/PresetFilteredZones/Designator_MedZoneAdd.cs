
namespace PresetFilteredZones
{

    public class Designator_MedZoneAdd : Designator_PresetZoneAdd
    {

        public Designator_MedZoneAdd()
        {
            zoneTypeToPlace = typeof(Zone_PresetStockpile);
            preset = PresetZoneType.Med;
            defaultLabel = Static.GetEnumDescription(preset);
            defaultDesc = Static.MedZoneDesc;
            icon = Static.TexMedZone;
            def = Static.DesMedZone;
        }
    }
}
