using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEquipment : ItemContainer
{
    [SerializeField] List<ClassSpecific_EquipmentSlot> armorSlots;
    [SerializeField] List<ClassSpecific_EquipmentSlot> accessorySlots;
    [SerializeField] List<ClassSpecific_EquipmentSlot> consumableSlots;

    [SerializeField] TMP_Text HP_StatText;
    [SerializeField] TMP_Text ATK_StatText;
    [SerializeField] TMP_Text DEF_StatText;

    List<ClassSpecific_EquipmentSlot> slots = new List<ClassSpecific_EquipmentSlot>();

    public int HP = 1;
    public int ATK = 1;
    public int DEF = 1;


    protected new void OnEnable() {
        AggregateSlots();
        StartListenSlotHover();
        ProcessEquipmentStats();
    }
    protected new void OnDisable() {
        StopListenSlotHover();
    }


    // Make a list of all slots, regardless of subclass
    void AggregateSlots() {
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
            slots[i].hoverOnEvent += OnStartHoveringSlot;
            slots[i].OnEquipped -= ProcessEquipmentStats;
        }
    }


    void ProcessEquipmentStats() {

        // Clear old stats
        HP = 1;
        ATK = 1;
        DEF = 1;

        // Factor additive stats
        for (int i = 0; i < slots.Count; i++) {
            Item_SO item = slots[i].GetItemType();
            if (item == null)
                continue;

            HP += item.addStats[0];
            ATK += item.addStats[1];
            DEF += item.addStats[2];
        }

        // Factor multiplicative stats
        for (int i = 0; i < slots.Count; i++) {
            Item_SO item = slots[i].GetItemType();
            if (item == null)
                continue;

            HP *= item.multStats[0];
            ATK *= item.multStats[1];
            DEF *= item.multStats[2];
        }

        // Clamp stats between 1 and infinity
        HP = HP < 1 ? 1 : HP;
        ATK = ATK < 1 ? 1 : ATK;
        DEF = DEF < 1 ? 1 : DEF;

        UpdateStatText();
    }


    void UpdateStatText() {
        HP_StatText.text = HP.ToString();
        ATK_StatText.text = ATK.ToString();
        DEF_StatText.text = DEF.ToString();
    }
}
