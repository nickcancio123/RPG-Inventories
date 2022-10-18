using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoveredItemDisplay : MonoBehaviour
{
    [SerializeField] List<ItemContainer> containers;

    [SerializeField] Image hoveredItemImage;
    [SerializeField] TMP_Text hoveredItemName;
    [SerializeField] TMP_Text hoveredItemDescription;

    Item_SO hoveredItemType;


    void Update() {

        ItemSlot hoveredSlot = GetHoveredSlot();
        
        if (hoveredSlot == null) {
            DisplayNullItem();
            return;
        }

        hoveredItemType = hoveredSlot.GetItemType();

        if (hoveredItemType == null) {
            DisplayNullItem();
            return;
        }

        hoveredItemImage.sprite = hoveredItemType.icon;
        hoveredItemName.text = hoveredItemType.itemName;
        hoveredItemDescription.text = hoveredItemType.description;
    }

    ItemSlot GetHoveredSlot() {
        for (int i = 0; i < containers.Count; i++) {
            if (containers[i].IsHoveringOverContainer())
                return containers[i].GetHoveredSlot();
        }
        return null;
    }


    void DisplayNullItem() {
        hoveredItemImage.sprite = null;
        hoveredItemName.text = "";
        hoveredItemDescription.text = "";
    }
}
