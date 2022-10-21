using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PresetFilteredZones;

[StaticConstructorOnStartup]
internal class Harmony_Patches
{
    static Harmony_Patches()
    {
        var harmony = new Harmony("Mlie.PresetFilteredZones");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    [HarmonyPatch(typeof(Building_Storage), "GetGizmos")]
    private class Building_Storage_Patch
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

    [HarmonyPatch(typeof(Zone_Stockpile), "GetGizmos")]
    private class Zone_Stockpile_Patch
    {
        private static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> values, Zone_Stockpile __instance)
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
}