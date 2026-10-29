using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PresetFilteredZones;

[HarmonyPatch(typeof(Zone_Stockpile), nameof(Zone_Stockpile.GetGizmos))]
public static class Zone_Stockpile_GetGizmos
{
    public static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> values, Zone_Stockpile __instance)
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
            action = delegate { Static.SelectStockpilePreset(__instance); }
        };
        yield return selectPresetAction;
    }
}