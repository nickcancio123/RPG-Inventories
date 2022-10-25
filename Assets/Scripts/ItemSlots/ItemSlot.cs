using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Image itemIconDisplay;
    
    [SerializeField] protected Item_SO itemType;

    public event Action<ItemSlot> hoverOnEvent;

    bool isHoveringOverSlot = false;


    void Start() {
        UpdateDisplay();
    }

    public virtual void OnPointerEnter(PointerEventData pointerEventData) {
        if (hoverOnEvent != null)
            hoverOnEvent(this);

        isHoveringOverSlot = true;
    }

    public virtual void OnPointerExit(PointerEventData pointerEventData) {
        isHoveringOverSlot = false;
    }

    protected void UpdateDisplay() {
        if (itemType == null) {
            itemIconDisplay.sprite = null;
            itemIconDisplay.color = Color.clear;
            return;
        }

        itemIconDisplay.color = Color.white;
        itemIconDisplay.sprite = itemType.icon;
    }


    public Item_SO GetItemType() => itemType;

    public virtual bool SetItemType(Item_SO _itemType) {
        itemType = _itemType;
        UpdateDisplay();

        return true;
    }

    public bool IsHoveringOverSlot() {
        return isHoveringOverSlot;
    }
}
