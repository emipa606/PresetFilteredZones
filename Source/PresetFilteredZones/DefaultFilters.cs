using System.Collections.Generic;
using RimWorld;
using Verse;

namespace PresetFilteredZones
{
    public static class DefaultFilters
    {
        public static ThingFilter DefaultFilter_SHTF()
        {
            var filter = new ThingFilter();
            filter.SetAllow(ThingCategoryDefOf.Root, true);
            return filter;
        }


        public static ThingFilter DefaultFilter_MealZone()
        {
            var database = DefDatabase<ThingDef>.AllDefsListForReading;
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            foreach (var thingDef in database)
            {
                if (thingDef.comps.Any(c => c is CompProperties_Rottable) && thingDef.IsIngestible &&
                    (thingDef.ingestible.foodType & FoodTypeFlags.Meal) != 0)
                {
                    filter.SetAllow(thingDef, true);
                }
            }

            return filter;
        }


        public static ThingFilter DefaultFilter_MedZone()
        {
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            filter.SetAllow(ThingCategoryDefOf.Medicine, true);
            return filter;
        }


        public static ThingFilter DefaultFilter_MeatZone()
        {
            var database = DefDatabase<ThingDef>.AllDefsListForReading;
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            foreach (var thingDef in database)
            {
                if (thingDef.IsIngestible && thingDef.ingestible.sourceDef?.race != null &&
                    !thingDef.ingestible.sourceDef.race.Humanlike &&
                    thingDef.ingestible.sourceDef.race.FleshType != FleshTypeDefOf.Insectoid)
                {
                    filter.SetAllow(thingDef, true);
                }
            }

            filter.SetAllow(ThingCategoryDefOf.Corpses, false);
            return filter;
        }


        public static ThingFilter DefaultFilter_VegZone()
        {
            var database = DefDatabase<ThingDef>.AllDefsListForReading;
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            foreach (var thingDef in database)
            {
                if (thingDef.comps.Any(c => c is CompProperties_Rottable) && thingDef.IsIngestible && (
                    (thingDef.ingestible.foodType & FoodTypeFlags.VegetableOrFruit) != 0 ||
                    (thingDef.ingestible.foodType & FoodTypeFlags.Seed) != 0))
                {
                    filter.SetAllow(thingDef, true);
                }
            }

            return filter;
        }


        public static ThingFilter DefaultFilter_JoyZone()
        {
            var database = DefDatabase<ThingDef>.AllDefsListForReading;
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            foreach (var thingDef in database)
            {
                if (thingDef.IsIngestible && thingDef.ingestible.joyKind != null &&
                    thingDef.ingestible.joy > 0)
                {
                    filter.SetAllow(thingDef, true);
                }
            }

            return filter;
        }


        public static ThingFilter DefaultFilter_AnimalZone()
        {
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            filter.SetAllow(ThingCategoryDefOf.CorpsesAnimal, true);
            filter.SetAllow(ThingCategoryDefOf.CorpsesInsect, false);
            filter.SetAllow(SpecialThingFilterDef.Named("AllowRotten"), false);
            return filter;
        }


        public static ThingFilter DefaultFilter_OutdoorZone()
        {
            var list = new List<ThingDef>();
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            list.AddRange(ThingCategoryDefOf.ResourcesRaw.DescendantThingDefs);
            list.AddRange(ThingCategoryDefOf.Items.DescendantThingDefs);

            foreach (var thingDef in list)
            {
                if (thingDef.GetStatValueAbstract(StatDefOf.DeteriorationRate) == 0 &&
                    !thingDef.comps.Any(c => c is CompProperties_Rottable) && !thingDef.IsIngestible)
                {
                    filter.SetAllow(thingDef, true);
                }
            }

            return filter;
        }


        public static ThingFilter DefaultFilter_IndoorZone()
        {
            var database = DefDatabase<ThingDef>.AllDefsListForReading;
            var filter = new ThingFilter();
            filter.SetDisallowAll();

            foreach (var thingDef in database)
            {
                if (thingDef.GetStatValueAbstract(StatDefOf.DeteriorationRate) > 0)
                {
                    filter.SetAllow(thingDef, true);
                }
            }

            filter.SetAllow(ThingCategoryDefOf.Corpses, false);
            filter.SetAllow(SpecialThingFilterDef.Named("AllowRotten"), false);
            filter.SetAllow(SpecialThingFilterDef.Named("AllowPlantFood"), true);
            filter.SetAllow(SpecialThingFilterDef.Named("AllowNonDeadmansApparel"), true);
            filter.SetAllow(SpecialThingFilterDef.Named("AllowSmeltable"), true);
            filter.SetAllow(SpecialThingFilterDef.Named("AllowNonSmeltableWeapons"), true);

            return filter;
        }
    }
}