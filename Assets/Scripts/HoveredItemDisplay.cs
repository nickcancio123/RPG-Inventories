using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoveredItemDisplay : ItemDisplay
{
    [SerializeField] List<ItemContainer> containers;

    protected override void Update() {

        slot = GetHoveredSlot();
        base.Update();
    }

    ItemSlot GetHoveredSlot() {
        for (int i = 0; i < containers.Count; i++) {
            if (containers[i].IsHoveringOverContainer())
                return containers[i].GetHoveredSlot();
        }
        return null;
    }
}
