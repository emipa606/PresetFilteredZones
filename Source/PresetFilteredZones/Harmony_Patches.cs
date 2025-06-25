using System.Reflection;
using HarmonyLib;
using Verse;

namespace PresetFilteredZones;

[StaticConstructorOnStartup]
internal class Harmony_Patches
{
    static Harmony_Patches()
    {
        new Harmony("Mlie.PresetFilteredZones").PatchAll(Assembly.GetExecutingAssembly());
    }
}