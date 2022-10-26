using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateBuildTask : MonoBehaviour
{
    enum EBuildType {
        ATK,
        DEF,
        AGL
    }

    [SerializeField] GameObject inventory;
    [SerializeField] PlayerEquipment playerEquipment;
    [SerializeField] Tab armorTab;
    [SerializeField] Tab weaponsTab;
    [SerializeField] Tab accessoriesTab;

    [Header("Task UI")]

    [SerializeField] GameObject taskUIBody;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject finishButton;
    [SerializeField] TMP_Text taskTimeText;
    [SerializeField] TMP_Text maxBuildStatText;
    [SerializeField] TMP_Text userBuildStatText;
    [SerializeField] TMP_Text buildTypeText1;
    [SerializeField] TMP_Text buildTypeText2;

    [SerializeField] EBuildType buildType;


    float taskTime = 0;
    float taskStartTime = 0;

    int maxBuildStat = 0;
    int userBuildStat = 0; 


    void Start() {
        // Show and hide elements
        taskUIBody.gameObject.SetActive(true);
        inventory.gameObject.SetActive(false);
        finishButton.gameObject.SetActive(false);

        // Set text values
        buildTypeText1.text = buildType.ToString();
        buildTypeText2.text = buildType.ToString();
    }

    public void StartTask() {
        taskTime = 0;
        taskStartTime = Time.time;

        ComputeMaxBuildStat();

        // Show and hide elements
        taskUIBody.gameObject.SetActive(false);
        finishButton.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
    }

    public void EndTask() {

        // Show and hide elements
        taskUIBody.gameObject.SetActive(true);
        finishButton.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);

        // Set text values
        taskTime = Time.time - taskStartTime;
        taskTimeText.text = taskTime.ToString();

        maxBuildStatText.text = maxBuildStat.ToString();
        
        switch(userBuildStat) {
            case (int)EBuildType.ATK:
                userBuildStat = playerEquipment.GetATK();
                break;
            case (int)EBuildType.DEF:
                userBuildStat = playerEquipment.GetDEF();
                break;
            case (int)EBuildType.AGL:
                userBuildStat = playerEquipment.GetAGL();
                break;
        }
        print("User made stat: " + userBuildStat);

        userBuildStatText.text = userBuildStat.ToString();
    }

    void ComputeMaxBuildStat() {

        int armorAdd = 0, armorMult = 1;
        int weaponAdd = 0, weaponMult = 1;
        int accessoryAdd = 0, accessoryMult = 1;
        
        GetEquipmentSetMaxStat(armorTab.itemSlots, out armorAdd, out armorMult);
        GetEquipmentSetMaxStat(weaponsTab.itemSlots, out  weaponAdd, out weaponMult);
        GetEquipmentSetMaxStat(accessoriesTab.itemSlots, out accessoryAdd, out accessoryMult);

        int addStat = armorAdd + weaponAdd + accessoryAdd;
        int multStat = armorMult * weaponMult * accessoryMult;

        maxBuildStat = (1 + addStat) * multStat;
    }

    void GetEquipmentSetMaxStat(List<ItemSlot> slots, out int addStat, out int multStat) {

        addStat = 0;
        multStat = 1;

        int highestStat = -1000;
        ItemSlot[] testSet = new ItemSlot[3];
        ItemSlot[] bestSet = new ItemSlot[3];

        for (int i = 0; i < slots.Count; i++) {
            if (slots[i].GetItemType() == null)
                continue;

            testSet[0] = slots[i];

            for (int j = 0; j < slots.Count; j++) {
                if (j == i)
                    continue;
                else if (slots[j].GetItemType() == null)
                    continue;
                else
                    testSet[1] = slots[j];

                for (int k = 0; k < slots.Count; k++) {
                    if (k == i || k == j)
                        continue;
                    else if (slots[k].GetItemType() == null)
                        continue;
                    else
                        testSet[2] = slots[k];

                    int testStat = 1;
                    // Additive
                    for (int a = 0; a < 3; a++)
                        testStat += testSet[a].GetItemType().addStats[(int)buildType];
                    // Multiplicative
                    for (int a = 0; a < 3; a++)
                        testStat *= testSet[a].GetItemType().multStats[(int)buildType];

                    if (testStat > highestStat) {
                        highestStat = testStat;
                        bestSet[0] = testSet[0];
                        bestSet[1] = testSet[1];
                        bestSet[2] = testSet[2];
                    }
                }
            }
        }

        for (int a = 0; a < 3; a++) {
            addStat += bestSet[a].GetItemType().addStats[(int)buildType];
            multStat *= bestSet[a].GetItemType().multStats[(int)buildType];
        }

        print("Final:  " + bestSet[0].GetItemType() + " " + bestSet[1].GetItemType() + " " + bestSet[2].GetItemType() + "   Add: " + addStat + "   Mult: " + multStat);

        return;
    }
    
}
