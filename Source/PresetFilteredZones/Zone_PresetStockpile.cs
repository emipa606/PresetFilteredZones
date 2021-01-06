using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using RimWorld;
using Verse;

namespace PresetFilteredZones
{

    public class Zone_PresetStockpile : Zone, IStoreSettingsParent, ISlotGroupParent
    {

        public StorageSettings settings;
        public ThingFilter thingFilter;
        public SlotGroup slotGroup;
        private static readonly ITab StorageTab = new ITab_Storage();
        private PresetZoneType zoneType;

        public PresetZoneType ZoneType => zoneType;

        public new Map Map => zoneManager.map;

        public bool StorageTabVisible => true;

        public bool IgnoreStoredThingsBeauty => false;

        protected override Color NextZoneColor => PresetZoneColorUtility.NewZoneColor(zoneType);


        public Zone_PresetStockpile()
        {
        }


        public Zone_PresetStockpile(PresetZoneType preset, ZoneManager zoneManager) : base(Static.GetEnumDescription(preset), zoneManager)
        {
            zoneType = preset;
            cells = AllSlotCells().ToList();
            settings = new StorageSettings(this)
            {
                filter = Static.SetFilterFromPreset(preset),
                Priority = StoragePriority.Important
            };
            slotGroup = new SlotGroup(this);
            color = NextZoneColor;
        }




        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Deep.Look(ref settings, "settings", new object[] { this });
            if (Scribe.mode != LoadSaveMode.Saving)
            {
                slotGroup = new SlotGroup(this);
            }
            Scribe_Values.Look(ref zoneType, "zoneType", PresetZoneType.None);
        }


        public override void AddCell(IntVec3 sq)
        {
            base.AddCell(sq);
            if (slotGroup != null)
            {
                slotGroup.Notify_AddedCell(sq);
            }
        }


        public override void RemoveCell(IntVec3 sq)
        {
            base.RemoveCell(sq);
            slotGroup.Notify_LostCell(sq);
        }


        //public new void Deregister()
        //{
        //    base.Deregister();
        //    slotGroup.Notify_ParentDestroying();
        //}


        public override IEnumerable<InspectTabBase> GetInspectTabs()
        {
            yield return StorageTab;
            var returnTabs = base.GetInspectTabs();
            if (returnTabs != null)
            {
                foreach (InspectTabBase tab in returnTabs)
                {
                    yield return tab;
                }
            }
        }


        public override IEnumerable<Gizmo> GetGizmos()
        {
            //yield return new Command_Action() {
            //  icon = GizmoShadeFor(zoneType),
            //  defaultLabel = Static.GizmoShadeLabel,
            //  defaultDesc = Static.GizmoShadeDesc,
            //  activateSound = SoundDefOf.Click,
            //  action = () => {
            //    color = NextZoneColor;
            //    for (int c = 0; c < Cells.Count; c++) {
            //      Map.mapDrawer.MapMeshDirty(Cells[c], MapMeshFlag.Zone);
            //    }
            //  }
            //};

            foreach (Gizmo giz in base.GetGizmos())
            {
                yield return giz;
            }

            foreach (Gizmo giz in StorageSettingsClipboard.CopyPasteGizmosFor(settings))
            {
                yield return giz;
            }

            yield return new Command_Action
            {
                icon = Static.StockpileGizmo,
                defaultLabel = "FZN_GizmoPresetLabel".Translate(),
                defaultDesc = "FZN_GizmoPresetDesc".Translate(),
                action = delegate ()
                {
                    Static.SelectStockpilePreset(this);
                }
            };
        }


        public SlotGroup GetSlotGroup()
        {
            return slotGroup;
        }


        public IEnumerable<IntVec3> AllSlotCells()
        {
            foreach (IntVec3 c in Cells)
            {
                yield return c;
            }
        }


        public List<IntVec3> AllSlotCellsList()
        {
            if (cells == null)
            {
                cells = AllSlotCells().ToList();
            }
            return cells;
        }


        public StorageSettings GetParentStoreSettings()
        {
            return null;
        }


        public StorageSettings GetStoreSettings()
        {
            return settings;
        }


        public string SlotYielderLabel()
        {
            return label;
        }


        public void Notify_ReceivedThing(Thing newItem)
        {
            if (newItem.def.storedConceptLearnOpportunity != null)
            {
                LessonAutoActivator.TeachOpportunity(newItem.def.storedConceptLearnOpportunity, OpportunityType.GoodToKnow);
            }
        }


        public void Notify_LostThing(Thing newItem)
        {
        }

        bool IHaulDestination.Accepts(Thing t)
        {
            return settings.filter.Allows(t);
        }


        //public static Texture2D GizmoShadeFor(PresetZoneType type) {
        //  if (type == PresetZoneType.Meal) {
        //    return Static.GizmoShadeMeal;
        //  }
        //  if (type == PresetZoneType.Med) {
        //    return Static.GizmoShadeMed;
        //  }
        //  if (type == PresetZoneType.Meat) {
        //    return Static.GizmoShadeMeat;
        //  }
        //  if (type == PresetZoneType.Veg) {
        //    return Static.GizmoShadeVeg;
        //  }
        //  if (type == PresetZoneType.Joy) {
        //    return Static.GizmoShadeJoy;
        //  }
        //  if (type == PresetZoneType.Animal) {
        //    return Static.GizmoShadeAnimal;
        //  }

        //  return BaseContent.BadTex;
        //}
    }
}
