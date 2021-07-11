using RimWorld;
using Verse;

namespace PresetFilteredZones
{
    public class Designator_PresetZoneAdd : Designator_ZoneAdd
    {
        protected DesignationDef def;

        protected PresetZoneType preset;


        protected override string NewZoneLabel => Static.GetEnumDescription(preset);


        protected override Zone MakeNewZone()
        {
            return new Zone_PresetStockpile(preset, Find.CurrentMap.zoneManager);
        }


        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            var result = base.CanDesignateCell(c);
            if (!result.Accepted)
            {
                return result;
            }

            var terrain = c.GetTerrain(Map);
            if (terrain.passability == Traversability.Impassable)
            {
                return false;
            }

            var list = Map.thingGrid.ThingsListAt(c);
            foreach (var thing in list)
            {
                if (!thing.def.CanOverlapZones)
                {
                    return false;
                }
            }

            var zone = Map.zoneManager.ZoneAt(c);
            if (zone == null || zone.GetType() != typeof(Zone_PresetStockpile))
            {
                return true;
            }

            if (zone is Zone_PresetStockpile z && z.ZoneType != preset)
            {
                return false;
            }

            return true;
        }
    }
}