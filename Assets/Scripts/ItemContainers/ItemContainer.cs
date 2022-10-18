using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour
{
    protected ItemSlot hoveredSlot;


    protected void OnEnable() => StartListenSlotHover();
    protected void OnDisable() => StopListenSlotHover();


    protected virtual void StartListenSlotHover() { }
    protected virtual void StopListenSlotHover() { }


    protected virtual void OnStartHoveringSlot(ItemSlot _hoveredSlot) {
        hoveredSlot = _hoveredSlot;
    }


    // Accessors
    public ItemSlot GetHoveredSlot() => hoveredSlot;

    public bool IsHoveringOverContainer() {
        if (hoveredSlot == null)
            return false;

        return hoveredSlot.IsHoveringOverSlot();
    }

}
