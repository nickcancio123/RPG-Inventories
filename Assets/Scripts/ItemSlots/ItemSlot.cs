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

    public void OnPointerEnter(PointerEventData eventData) {
        if (hoverOnEvent != null)
            hoverOnEvent(this);

        isHoveringOverSlot = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHoveringOverSlot = false;
    }

    protected void UpdateDisplay() {
        if (itemType == null) {
            itemIconDisplay.sprite = null;
            return;
        }

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
