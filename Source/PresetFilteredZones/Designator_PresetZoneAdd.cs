using System.Collections.Generic;

using RimWorld;
using Verse;

namespace PresetFilteredZones
{

    public class Designator_PresetZoneAdd : Designator_ZoneAdd
    {

        protected PresetZoneType preset;
        protected DesignationDef def;


        protected override string NewZoneLabel => Static.GetEnumDescription(preset);


        protected override Zone MakeNewZone()
        {
            return new Zone_PresetStockpile(preset, Find.CurrentMap.zoneManager);
        }


        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            AcceptanceReport result = base.CanDesignateCell(c);
            if (!result.Accepted)
            {
                return result;
            }
            TerrainDef terrain = c.GetTerrain(Map);
            if (terrain.passability == Traversability.Impassable)
            {
                return false;
            }
            List<Thing> list = Map.thingGrid.ThingsListAt(c);
            for (var i = 0; i < list.Count; i++)
            {
                if (!list[i].def.CanOverlapZones)
                {
                    return false;
                }
            }
            Zone zone = Map.zoneManager.ZoneAt(c);
            if (zone != null && zone.GetType() == typeof(Zone_PresetStockpile))
            {
                var z = zone as Zone_PresetStockpile;
                if (z.ZoneType != preset)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
