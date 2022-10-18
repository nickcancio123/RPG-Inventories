using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory_ItemSlot : ItemSlot
{
    public override bool SetItemType(Item_SO _itemType) {
        if (!(itemType is Accessory_SO))
            return false;

        base.SetItemType(itemType);

        return true;
    }
}
