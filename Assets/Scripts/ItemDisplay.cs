using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDescription;

    [SerializeField] protected ItemSlot slot;

    Item_SO itemType;


    protected virtual void Update() {

        if (slot == null) {
            DisplayNullItem();
            return;
        }

        itemType = slot.GetItemType();

        if (itemType == null) {
            DisplayNullItem();
            return;
        }

        if (itemImage)
            itemImage.sprite = itemType.icon;

        itemName.text = itemType.itemName;
        itemDescription.text = itemType.description;
    }


    void DisplayNullItem() {
        if (itemImage)
            itemImage.sprite = null;
        
        itemName.text = "";
        itemDescription.text = "";
    }
}
