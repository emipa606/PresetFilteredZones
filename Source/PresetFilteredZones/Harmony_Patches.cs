using System.Reflection;
using HarmonyLib;
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
}