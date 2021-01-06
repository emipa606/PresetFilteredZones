
using Verse;

namespace PresetFilteredZones {

  public class Designator_AnimalZoneAdd : Designator_PresetZoneAdd {

    public Designator_AnimalZoneAdd() {
      zoneTypeToPlace = typeof(Zone_PresetStockpile);
      preset = PresetZoneType.Animal;
      defaultLabel = Static.GetEnumDescription(preset);
      defaultDesc = Static.AnimalZoneDesc;
      icon = Static.TexAnimalZone;
      def = Static.DesAnimalZone;
    }
  }
}
