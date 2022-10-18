using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable_ItemSlot : ItemSlot
{
    public override bool SetItemType(Item_SO _itemType) {
        if (!(itemType is Consumable_SO))
            return false;

        base.SetItemType(itemType);

        return true;
    }
}
