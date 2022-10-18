using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClassSpecific_EquipmentSlot : ClassSpecific_ItemSlot
{
    public event Action OnEquipped;

    public override bool SetItemType(Item_SO _itemType) {

        base.SetItemType(_itemType);

        if (OnEquipped != null)
            OnEquipped();

        return true;
    }
}
