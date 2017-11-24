using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using RimWorld;
using Verse;

namespace PresetFilteredZones {

  public class Zone_PresetStockpile : Zone, IStoreSettingsParent, ISlotGroupParent {

    public StorageSettings settings;
    public ThingFilter thingFilter;
    public SlotGroup slotGroup;
    private static readonly ITab StorageTab = new ITab_Storage();
    private PresetZoneType zoneType;

    public PresetZoneType ZoneType {
      get { return zoneType; }
    }

    public new Map Map {
      get { return zoneManager.map; }
    }

    public bool StorageTabVisible {
      get {
        return true;
      }
    }

    public bool IgnoreStoredThingsBeauty {
      get {
        return false;
      }
    }

    protected override Color NextZoneColor {
      get {
        return PresetZoneColorUtility.NewZoneColor(zoneType);
      }
    }


    public Zone_PresetStockpile() {
    }


    public Zone_PresetStockpile(PresetZoneType preset, ZoneManager zoneManager) : base(Static.GetEnumDescription(preset), zoneManager) {
      zoneType = preset;
      cells = AllSlotCells().ToList();
			settings = new StorageSettings(this) {
				filter = SetFilterFromPreset(preset),
				Priority = StoragePriority.Important
			};
			slotGroup = new SlotGroup(this);
      color = NextZoneColor;
    }


    private ThingFilter SetFilterFromPreset(PresetZoneType preset) {
      List<ThingDef> database = DefDatabase<ThingDef>.AllDefsListForReading;

      if (preset == PresetZoneType.Meal) {
        return DefaultFilters.DefaultFilter_MealZone();
      }
      if (preset == PresetZoneType.Med) {
        return DefaultFilters.DefaultFilter_MedZone();
      }
      if (preset == PresetZoneType.Meat) {
        return DefaultFilters.DefaultFilter_MeatZone();
      }
      if (preset == PresetZoneType.Veg) {
        return DefaultFilters.DefaultFilter_VegZone();
      }
      if (preset == PresetZoneType.Joy) {
        return DefaultFilters.DefaultFilter_JoyZone();
      }
      if (preset == PresetZoneType.Animal) {
        return DefaultFilters.DefaultFilter_AnimalZone();
      }
      if (preset == PresetZoneType.Outdoor) {
        return DefaultFilters.DefaultFilter_OutdoorZone();
      }
			if (preset == PresetZoneType.Indoor) {
				return DefaultFilters.DefaultFilter_IndoorZone();
			}
			Log.Error("PresetFilteredZones:: Trying to make a zone with PresetZoneType of None.");
      return DefaultFilters.DefaultFilter_SHTF();
    }


    public override void ExposeData() {
      base.ExposeData();
      Scribe_Deep.Look(ref settings, "settings", new object[] {this});
      if (Scribe.mode == LoadSaveMode.PostLoadInit) {
        slotGroup = new SlotGroup(this);
      }
      Scribe_Values.Look(ref zoneType, "zoneType", PresetZoneType.None);
    }


    public override void AddCell(IntVec3 sq) {
      base.AddCell(sq);
      if (slotGroup != null) {
        slotGroup.Notify_AddedCell(sq);
      }
    }


    public override void RemoveCell(IntVec3 sq) {
      base.RemoveCell(sq);
      slotGroup.Notify_LostCell(sq);
    }


    public override void Deregister() {
      base.Deregister();
      slotGroup.Notify_ParentDestroying();
    }


    public override IEnumerable<InspectTabBase> GetInspectTabs() {

      yield return StorageTab;

      foreach (InspectTabBase tab in base.GetInspectTabs()) {
        yield return tab;
      }
    }


    public override IEnumerable<Gizmo> GetGizmos() {
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

      foreach (Gizmo giz in base.GetGizmos()) {
        yield return giz;
      }

      foreach (Gizmo giz in StorageSettingsClipboard.CopyPasteGizmosFor(settings)) {
        yield return giz;
      }
    }


    public SlotGroup GetSlotGroup() {
      return slotGroup;
    }


    public IEnumerable<IntVec3> AllSlotCells() {
      foreach (IntVec3 c in Cells) {
        yield return c;
      }
    }


    public List<IntVec3> AllSlotCellsList() {
      if (cells == null) {
        cells = AllSlotCells().ToList();
      }
      return cells;
    }


    public StorageSettings GetParentStoreSettings() {
      return null;
    }


    public StorageSettings GetStoreSettings() {
      return settings;
    }


    public string SlotYielderLabel() {
      return label;
    }


    public void Notify_ReceivedThing(Thing newItem) {
      if (newItem.def.storedConceptLearnOpportunity != null) {
        LessonAutoActivator.TeachOpportunity(newItem.def.storedConceptLearnOpportunity, OpportunityType.GoodToKnow);
      }
    }


    public void Notify_LostThing(Thing newItem) {
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
