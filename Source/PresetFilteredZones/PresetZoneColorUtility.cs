using System.Collections.Generic;

using UnityEngine;
using Verse;

namespace PresetFilteredZones {

  public enum PresetZoneType {
    None,
    [Description("Frozen Meals")]
    Meal,
    [Description("Frozen Meat")]
    Meat,
    [Description("Frozen Veg")]
    Veg,
    [Description("Medicine Stockpile")]
    Med,
    [Description("Joy Stockpile")]
    Joy,
    [Description("Frozen Animals")]
    Animal
  }



  [StaticConstructorOnStartup]
  public static class PresetZoneColorUtility {

    private const float ZoneOpacity = 0.15f;
    private static List<Color> mealZonePalette;
    private static List<Color> medZonePalette;
    private static List<Color> meatZonePalette;
    private static List<Color> vegZonePalette;
    private static List<Color> joyZonePalette;
    private static List<Color> animalZonePalette;


    static PresetZoneColorUtility() {
      PaintMealZone();
      PaintMedZone();
      PaintMeatZone();
      PaintVegZone();
      PaintJoyZone();
      PaintAnimalZone();
    }


    public static Color NewZoneColor(PresetZoneType type) {
      if (type == PresetZoneType.Meal) {
        return mealZonePalette.RandomElement();
      }
      if (type == PresetZoneType.Med) {
        return medZonePalette.RandomElement();
      }
      if (type == PresetZoneType.Meat) {
        return meatZonePalette.RandomElement();
      }
      if (type == PresetZoneType.Veg) {
        return vegZonePalette.RandomElement();
      }
      if (type == PresetZoneType.Joy) {
        return joyZonePalette.RandomElement();
      }
      if (type == PresetZoneType.Animal) {
        return animalZonePalette.RandomElement();
      }

      return ColorLibrary.Grey;
    }


    private static List<Color> Dilute(List<Color> palette) {
      List<Color> dilutedColors = new List<Color>();
      foreach (Color color in palette) {
        Color c = new Color(color.r, color.g, color.b, ZoneOpacity);
        dilutedColors.Add(c);
      }
      return dilutedColors;
    }


    private static void PaintMealZone() {
      mealZonePalette = Dilute(new List<Color>() {
        ColorLibrary.Purple,
        ColorLibrary.Violet,
        ColorLibrary.LightPurple,
        ColorLibrary.DeepPurple,
        ColorLibrary.RoyalPurple,
        ColorLibrary.Plum,
        ColorLibrary.BrightPurple,
        ColorLibrary.Indigo,
        ColorLibrary.Lilac,
        ColorLibrary.DarkPurple,
        ColorLibrary.Lavender
      });
    }


    private static void PaintMedZone() {
      medZonePalette = Dilute(new List<Color>() {
        ColorLibrary.Blue,
        ColorLibrary.SkyBlue,
        ColorLibrary.BabyBlue,
        ColorLibrary.PaleBlue,
        ColorLibrary.Navy,
        ColorLibrary.Aquamarine,
        ColorLibrary.BrightBlue,
        ColorLibrary.NavyBlue,
        ColorLibrary.RoyalBlue,
        ColorLibrary.Aqua,
        ColorLibrary.DarkBlue
      });
    }


    private static void PaintMeatZone() {
      meatZonePalette = Dilute(new List<Color>() {
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
      });
    }


    private static void PaintVegZone() {
      vegZonePalette = Dilute(new List<Color>() {
        ColorLibrary.Green,
        ColorLibrary.LightGreen,
        ColorLibrary.PastelGreen,
        ColorLibrary.Mint,
        ColorLibrary.PeaGreen,
        ColorLibrary.PukeGreen,
        ColorLibrary.GrassGreen,
        ColorLibrary.OliveGreen,
        ColorLibrary.PaleGreen,
        ColorLibrary.ForestGreen,
        ColorLibrary.DarkGreen
      });
    }


    private static void PaintJoyZone() {
      joyZonePalette = Dilute(new List<Color>() {
        ColorLibrary.Orange,
        ColorLibrary.Yellow,
        ColorLibrary.DarkOrange,
        ColorLibrary.Sand,
        ColorLibrary.LightOrange,
        ColorLibrary.Gold,
        ColorLibrary.Mustard
      });
    }


    private static void PaintAnimalZone() {
      animalZonePalette = Dilute(new List<Color>() {
        ColorLibrary.Brown,
        ColorLibrary.Leather,
        ColorLibrary.DarkBrown,
        ColorLibrary.Taupe,
        ColorLibrary.Khaki,
        ColorLibrary.LightBrown,
        ColorLibrary.Beige,
        ColorLibrary.Olive
      });
    }
  }
}
