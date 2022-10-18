using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Visual_Inventory : Inventory
{
    [SerializeField] Image hoveredItemImage;
    [SerializeField] TMP_Text hoveredItemName;
    [SerializeField] TMP_Text hoveredItemDescription;

    protected override void OnStartHoveringSlot(ItemSlot _hoveredSlot) {

        base.OnStartHoveringSlot(_hoveredSlot);

        Item_SO item = _hoveredSlot.GetItemType();

        if (item == null) {
            hoveredItemImage.sprite = null;
            hoveredItemName.text = "";
            hoveredItemDescription.text = "";
            return;
        }

        hoveredItemImage.sprite = item.icon;
        hoveredItemName.text = item.itemName;
        hoveredItemDescription.text = item.description;
    }
}

