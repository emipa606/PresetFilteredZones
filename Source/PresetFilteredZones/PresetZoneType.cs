using Verse;

namespace PresetFilteredZones;

public enum PresetZoneType
{
    None,
    [Description("FZN_LabelMealZone")] Meal,
    [Description("FZN_LabelMeatZone")] Meat,
    [Description("FZN_LabelVegZone")] Veg,
    [Description("FZN_LabelMedZone")] Med,
    [Description("FZN_LabelJoyZone")] Joy,
    [Description("FZN_LabelAnimalZone")] Animal,
    [Description("FZN_LabelOutdoorZone")] Outdoor,
    [Description("FZN_LabelIndoorZone")] Indoor
}