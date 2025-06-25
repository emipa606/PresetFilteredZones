using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PresetFilteredZones;

[HarmonyPatch(typeof(Building_Storage), nameof(Building_Storage.GetGizmos))]
public class Building_Storage_GetGizmos
{
    private static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> values, Building_Storage __instance)
    {
        foreach (var value in values)
        {
            yield return value;
        }

        var selectPresetAction = new Command_Action
        {
            icon = Static.StockpileGizmo,
            defaultLabel = "FZN_GizmoPresetLabel".Translate(),
            defaultDesc = "FZN_GizmoPresetDesc".Translate(),
            action = delegate { Static.SelectBuildingPreset(__instance); }
        };
        yield return selectPresetAction;
    }
}