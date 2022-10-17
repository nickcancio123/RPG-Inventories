using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Inventory_Visual : Inventory
{
    [SerializeField] Image hoveredItemImage;
    [SerializeField] TMP_Text hoveredItemName;
    [SerializeField] TMP_Text hoveredItemDescription;


    protected override void NewItemHovered(ItemSlot _hoveredItemSlot) {

        base.NewItemHovered(_hoveredItemSlot);

        Item_SO item = _hoveredItemSlot.GetItemType();

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

