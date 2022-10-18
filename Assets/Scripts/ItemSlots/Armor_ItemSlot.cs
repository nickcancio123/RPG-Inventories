using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_ItemSlot : ItemSlot
{
    public override bool SetItemType(Item_SO _itemType) {
        if (!(itemType is Armor_SO))
            return false;

        base.SetItemType(itemType);

        return true;
    }
}
