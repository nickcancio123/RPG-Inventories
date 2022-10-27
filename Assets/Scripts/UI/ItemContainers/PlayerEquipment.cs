using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class PlayerEquipment : ItemContainer
{
    [SerializeField] List<ClassSpecific_EquipmentSlot> armorSlots;
    [SerializeField] List<ClassSpecific_EquipmentSlot> accessorySlots;
    [SerializeField] List<ClassSpecific_EquipmentSlot> consumableSlots;

    [SerializeField] TMP_Text ATK_StatText; // Attack 
    [SerializeField] TMP_Text DEF_StatText; // Defense
    [SerializeField] TMP_Text AGL_StatText; // Agility
        
    List<ClassSpecific_EquipmentSlot> slots = new List<ClassSpecific_EquipmentSlot>();

    int ATK = 1;
    int DEF = 1;
    int AGL = 1;


    protected new void OnEnable() {
        AggregateSlots();
        StartListenSlotHover();
        ProcessEquipmentStats();
    }


    // Make a list of all slots, regardless of subclass
    void AggregateSlots() {
        slots.Clear();

        for (int i = 0; i < armorSlots.Count; i++) 
            slots.Add(armorSlots[i]);

        for (int i = 0; i < accessorySlots.Count; i++)
            slots.Add(accessorySlots[i]);

        for (int i = 0; i < consumableSlots.Count; i++)
            slots.Add(consumableSlots[i]);
    }


    // Also starts listening for OnEquipped
    protected override void StartListenSlotHover() {
        for (int i = 0; i < slots.Count; i++) {
            slots[i].hoverOnEvent += OnStartHoveringSlot;
            slots[i].OnEquipped += ProcessEquipmentStats;
        }
    }

    // Also stops listening for OnEquipped
    protected override void StopListenSlotHover() {
        for (int i = 0; i < slots.Count; i++) {
            slots[i].hoverOnEvent -= OnStartHoveringSlot;
            slots[i].OnEquipped -= ProcessEquipmentStats;
        }
    }


    void ProcessEquipmentStats() {
        // Clear old stats
        ATK = 1;
        DEF = 1;
        AGL = 1;

        // Factor additive stats
        for (int i = 0; i < slots.Count; i++) {
            Item_SO item = slots[i].GetItemType();
            if (item == null)
                continue;

            ATK += item.addStats[0];
            DEF += item.addStats[1];
            AGL += item.addStats[2];
        }

        // Factor multiplicative stats
        for (int i = 0; i < slots.Count; i++) {
            Item_SO item = slots[i].GetItemType();
            if (item == null)
                continue;

            ATK *= item.multStats[0];
            DEF *= item.multStats[1];
            AGL *= item.multStats[2];
        }

        UpdateStatText();
    }

    void UpdateStatText() {
        ATK_StatText.text = ATK.ToString();
        DEF_StatText.text = DEF.ToString();
        AGL_StatText.text = AGL.ToString();
    }


    public override List<ItemSlot> GetItemSlots() {
        List<ItemSlot> itemSlots = new List<ItemSlot>();
        for (int i = 0; i < slots.Count; i++) 
            itemSlots.Add(slots[i]);
       
        return itemSlots;
    }


    public bool IsItemTypeEquipped(Item_SO itemType) {
        for (int i = 0; i < slots.Count; i++) {
            if (slots[i].GetItemType() == itemType)
                return true;
        }
        return false;
    }


    public int GetATK() => ATK;
    public int GetDEF() => DEF;
    public int GetAGL() => AGL;
}
