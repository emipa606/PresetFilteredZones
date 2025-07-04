﻿using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace PresetFilteredZones;

public class Zone_PresetStockpile : Zone, ISlotGroupParent
{
    private static readonly ITab storageTab = new ITab_Storage();

    public StorageSettings Settings;
    private SlotGroup slotGroup;
    public ThingFilter ThingFilter;
    private PresetZoneType zoneType;


    public Zone_PresetStockpile()
    {
    }


    public Zone_PresetStockpile(PresetZoneType preset, ZoneManager zoneManager) : base(
        Static.GetEnumDescription(preset), zoneManager)
    {
        zoneType = preset;
        cells = AllSlotCells().ToList();
        Settings = new StorageSettings(this)
        {
            filter = Static.SetFilterFromPreset(preset),
            Priority = StoragePriority.Important
        };
        slotGroup = new SlotGroup(this);
        color = NextZoneColor;
    }

    public PresetZoneType ZoneType => zoneType;

    protected override Color NextZoneColor => PresetZoneColorUtility.NewZoneColor(zoneType);

    public new Map Map => zoneManager.map;
    public bool HaulDestinationEnabled { get; }

    public bool IgnoreStoredThingsBeauty => false;

    public string GroupingLabel => "StockpilePlural".Translate();

    public int GroupingOrder => -50;


    public SlotGroup GetSlotGroup()
    {
        return slotGroup;
    }


    public IEnumerable<IntVec3> AllSlotCells()
    {
        foreach (var c in Cells)
        {
            yield return c;
        }
    }


    public List<IntVec3> AllSlotCellsList()
    {
        cells ??= AllSlotCells().ToList();

        return cells;
    }


    public string SlotYielderLabel()
    {
        return label;
    }


    public void Notify_ReceivedThing(Thing newItem)
    {
        if (newItem.def.storedConceptLearnOpportunity != null)
        {
            LessonAutoActivator.TeachOpportunity(newItem.def.storedConceptLearnOpportunity,
                OpportunityType.GoodToKnow);
        }
    }


    public void Notify_LostThing(Thing newItem)
    {
    }

    bool IHaulDestination.Accepts(Thing t)
    {
        return Settings.filter.Allows(t);
    }

    public void Notify_SettingsChanged()
    {
    }

    public bool StorageTabVisible => true;


    public StorageSettings GetParentStoreSettings()
    {
        return null;
    }


    public StorageSettings GetStoreSettings()
    {
        return Settings;
    }


    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Deep.Look(ref Settings, "settings", this);
        if (Scribe.mode != LoadSaveMode.Saving)
        {
            slotGroup = new SlotGroup(this);
        }

        Scribe_Values.Look(ref zoneType, "zoneType");
    }


    public override void AddCell(IntVec3 sq)
    {
        base.AddCell(sq);
        slotGroup?.Notify_AddedCell(sq);
    }


    public override void RemoveCell(IntVec3 sq)
    {
        base.RemoveCell(sq);
        slotGroup.Notify_LostCell(sq);
    }


    public override IEnumerable<InspectTabBase> GetInspectTabs()
    {
        yield return storageTab;
        var returnTabs = base.GetInspectTabs();
        if (returnTabs == null)
        {
            yield break;
        }

        foreach (var tab in returnTabs)
        {
            yield return tab;
        }
    }

    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (var giz in base.GetGizmos())
        {
            yield return giz;
        }

        foreach (var giz in StorageSettingsClipboard.CopyPasteGizmosFor(Settings))
        {
            yield return giz;
        }

        yield return new Command_Action
        {
            icon = Static.StockpileGizmo,
            defaultLabel = "FZN_GizmoPresetLabel".Translate(),
            defaultDesc = "FZN_GizmoPresetDesc".Translate(),
            action = delegate { Static.SelectStockpilePreset(this); }
        };
    }
}