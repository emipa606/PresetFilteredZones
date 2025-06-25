using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PresetFilteredZones;

[StaticConstructorOnStartup]
public static class PresetZoneColorUtility
{
    private const float ZoneOpacity = 0.15f;
    private static List<Color> mealZonePalette;
    private static List<Color> medZonePalette;
    private static List<Color> meatZonePalette;
    private static List<Color> vegZonePalette;
    private static List<Color> joyZonePalette;
    private static List<Color> animalZonePalette;
    private static List<Color> outdoorZonePalette;


    static PresetZoneColorUtility()
    {
        PaintMealZone();
        paintMedZone();
        paintMeatZone();
        paintVegZone();
        paintJoyZone();
        paintAnimalZone();
        paintOutdoorZone();
    }


    public static Color NewZoneColor(PresetZoneType type)
    {
        switch (type)
        {
            case PresetZoneType.Meal:
                return mealZonePalette.RandomElement();
            case PresetZoneType.Med:
                return medZonePalette.RandomElement();
            case PresetZoneType.Meat:
                return meatZonePalette.RandomElement();
            case PresetZoneType.Veg:
                return vegZonePalette.RandomElement();
            case PresetZoneType.Joy:
                return joyZonePalette.RandomElement();
            case PresetZoneType.Animal:
                return animalZonePalette.RandomElement();
            case PresetZoneType.Outdoor:
            case PresetZoneType.Indoor:
                return outdoorZonePalette.RandomElement();
            default:
                return ColorLibrary.Grey;
        }
    }


    private static List<Color> dilute(List<Color> palette)
    {
        var dilutedColors = new List<Color>();
        foreach (var color in palette)
        {
            var c = new Color(color.r, color.g, color.b, ZoneOpacity);
            dilutedColors.Add(c);
        }

        return dilutedColors;
    }


    private static void PaintMealZone()
    {
        mealZonePalette = dilute([
            ColorLibrary.Purple,
            ColorLibrary.Violet,
            ColorLibrary.DeepPurple,
            ColorLibrary.RoyalPurple,
            ColorLibrary.Plum,
            ColorLibrary.BrightPurple,
            ColorLibrary.Indigo,
            ColorLibrary.Lilac,
            ColorLibrary.DarkPurple,
            ColorLibrary.Lavender
        ]);
    }


    private static void paintMedZone()
    {
        medZonePalette = dilute([
            ColorLibrary.Blue,
            ColorLibrary.BabyBlue,
            ColorLibrary.Navy,
            ColorLibrary.Aquamarine,
            ColorLibrary.BrightBlue,
            ColorLibrary.NavyBlue,
            ColorLibrary.RoyalBlue,
            ColorLibrary.Aqua,
            ColorLibrary.DarkBlue
        ]);
    }


    private static void paintMeatZone()
    {
        meatZonePalette = dilute([
            ColorLibrary.Red,
            ColorLibrary.Magenta,
            ColorLibrary.Burgundy,
            ColorLibrary.BrickRed,
            ColorLibrary.DarkRed,
            ColorLibrary.Rose,
            ColorLibrary.DarkPink,
            ColorLibrary.HotPink,
            ColorLibrary.Salmon,
            ColorLibrary.Maroon,
            ColorLibrary.Mauve
        ]);
    }


    private static void paintVegZone()
    {
        vegZonePalette = dilute([
            ColorLibrary.Green,
            ColorLibrary.PastelGreen,
            ColorLibrary.PeaGreen,
            ColorLibrary.PukeGreen,
            ColorLibrary.GrassGreen,
            ColorLibrary.OliveGreen,
            ColorLibrary.ForestGreen,
            ColorLibrary.DarkGreen
        ]);
    }


    private static void paintJoyZone()
    {
        joyZonePalette = dilute([
            ColorLibrary.Orange,
            ColorLibrary.Yellow,
            ColorLibrary.DarkOrange,
            ColorLibrary.Sand,
            ColorLibrary.LightOrange,
            ColorLibrary.Gold,
            ColorLibrary.Mustard
        ]);
    }


    private static void paintAnimalZone()
    {
        animalZonePalette = dilute([
            ColorLibrary.Brown,
            ColorLibrary.Leather,
            ColorLibrary.DarkBrown
        ]);
    }


    private static void paintOutdoorZone()
    {
        outdoorZonePalette = [];
        foreach (var color in mealZonePalette)
        {
            var v = color.grayscale;
            outdoorZonePalette.Add(new Color(v, v, v, ZoneOpacity));
        }
    }
}