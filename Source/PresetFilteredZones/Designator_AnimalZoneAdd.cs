namespace PresetFilteredZones;

public class Designator_AnimalZoneAdd : Designator_PresetZoneAdd
{
    public Designator_AnimalZoneAdd()
    {
        zoneTypeToPlace = typeof(Zone_PresetStockpile);
        Preset = PresetZoneType.Animal;
        defaultLabel = Static.GetEnumDescription(Preset);
        defaultDesc = Static.AnimalZoneDesc;
        icon = Static.TexAnimalZone;
        Def = Static.DesAnimalZone;
    }
}