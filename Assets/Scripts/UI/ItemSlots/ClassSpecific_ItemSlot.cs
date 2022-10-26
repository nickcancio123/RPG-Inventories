using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClassSpecific_ItemSlot : ItemSlot
{
    [SerializeField] protected Item_SO targetClassInstance;

    public override bool SetItemType(Item_SO _itemType) {

        if (_itemType != null) {
            Type targetClass = targetClassInstance.GetType();
            Type itemClass = _itemType.GetType();

            bool isCorrectClass = itemClass.IsEquivalentTo(targetClass);
            if (!isCorrectClass)
                return false;
        }

        base.SetItemType(_itemType);

        return true;
    }
}

