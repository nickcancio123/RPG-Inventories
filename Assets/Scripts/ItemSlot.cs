using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] Image itemIconDisplay;
    
    [SerializeField] Item_SO itemType;

    public event Action<ItemSlot> hoverEvent;



    void Start() {
        UpdateDisplay();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (hoverEvent != null)
            hoverEvent(this);
    }

    void UpdateDisplay() {
        if (itemType == null) {
            itemIconDisplay.sprite = null;
            return;
        }

        itemIconDisplay.sprite = itemType.icon;
    }


    public Item_SO GetItemType() => itemType;

    public void SetItemType(Item_SO _itemType) {
        itemType = _itemType;
        UpdateDisplay();
    }
}
