using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : ItemContainer
{
    [SerializeField] List<Armor_ItemSlot> armorSlots;
    [SerializeField] List<Accessory_ItemSlot> accessorySlots;
    [SerializeField] List<Consumable_ItemSlot> consumableSlots;


}
