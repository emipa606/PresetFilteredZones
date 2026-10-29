using System.Reflection;
using HarmonyLib;
using Verse;

namespace PresetFilteredZones;

[StaticConstructorOnStartup]
internal static class Harmony_Patches
{
    static Harmony_Patches()
    {
        new Harmony("Mlie.PresetFilteredZones").PatchAll(Assembly.GetExecutingAssembly());
    }
}