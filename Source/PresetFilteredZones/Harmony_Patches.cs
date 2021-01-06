
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Verse;

namespace PresetFilteredZones
{
    [StaticConstructorOnStartup]
    class Harmony_Patches
    {
        static Harmony_Patches()
        {
            var harmony = new Harmony("Mlie.PresetFilteredZones");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(Building_Storage), "GetGizmos")]
        class Building_Storage_Patch
        {
            static void Postfix(ref IEnumerable<Gizmo> __result, Building_Storage __instance)
            {
                var gizmos = __result.ToList();
                var selectPresetAction = new Command_Action
                {
                    icon = Static.StockpileGizmo,
                    defaultLabel = "FZN_GizmoPresetLabel".Translate(),
                    defaultDesc = "FZN_GizmoPresetDesc".Translate(),
                    action = delegate ()
                    {
                        Static.SelectBuildingPreset(__instance);
                    }
                };
                gizmos.Add(selectPresetAction);
                __result = gizmos;
            }
        }

        [HarmonyPatch(typeof(Zone_Stockpile), "GetGizmos")]
        class Zone_Stockpile_Patch
        {
            static void Postfix(ref IEnumerable<Gizmo> __result, Zone_Stockpile __instance)
            {
                var gizmos = __result.ToList();
                var selectPresetAction = new Command_Action
                {
                    icon = Static.StockpileGizmo,
                    defaultLabel = "FZN_GizmoPresetLabel".Translate(),
                    defaultDesc = "FZN_GizmoPresetDesc".Translate(),
                    action = delegate ()
                    {
                        Static.SelectStockpilePreset(__instance);
                    }
                };
                gizmos.Add(selectPresetAction);
                __result = gizmos;
            }
        }


    }
}
