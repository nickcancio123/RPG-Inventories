using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : ItemContainer
{
    // Tabs
    [SerializeField] int defaultTabOpen = 0;
    [SerializeField] protected List<Tab> tabs;

    protected new void OnEnable() {
        base.OnEnable();
        OpenTab(tabs[defaultTabOpen]);
    }


    protected override void StartListenSlotHover() {
        for (int t = 0; t < tabs.Count; t++) {
            for (int i = 0; i < tabs[t].itemSlots.Count; i++) {
                tabs[t].itemSlots[i].hoverOnEvent += OnStartHoveringSlot;
            }
        }
    }
    protected override void StopListenSlotHover() {
        for (int t = 0; t < tabs.Count; t++) {
            for (int i = 0; i < tabs[t].itemSlots.Count; i++) {
                tabs[t].itemSlots[i].hoverOnEvent -= OnStartHoveringSlot;
            }
        }
    }


    public void OpenTab(Tab callingTab) {
        for (int i = 0; i < tabs.Count; i++) {
            bool open = callingTab == tabs[i];
            tabs[i].OpenCloseTab(open);
        }
    }

    public override List<ItemSlot> GetItemSlots() {
        List<ItemSlot> slots = new List<ItemSlot>();
        for (int t = 0; t < tabs.Count; t++) {
            for (int i = 0; i < tabs[t].itemSlots.Count; i++) {
                slots.Add(tabs[t].itemSlots[i]);
            }
        }
        return slots;
    }
}