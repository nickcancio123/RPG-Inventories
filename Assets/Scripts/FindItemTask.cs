using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindItemTask : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject startButton;
    [SerializeField] PlayerEquipment playerEquipment;

    [SerializeField] TMP_Text taskTimeText;

    [SerializeField] Item_SO targetItemType;

    float taskTime = 0;
    float taskStartTime = 0;

    bool taskStarted = false;


    void Start() {
        if (inventory)
            inventory.gameObject.SetActive(false);
    }

    public void StartTask() {
        taskTime = 0;
        taskStartTime = Time.time;
        taskStarted = true;

        if (inventory)
            inventory.SetActive(true);
    }

    void Update() {
        if (taskStarted) {
            if (playerEquipment)
                if (playerEquipment.IsItemTypeEquipped(targetItemType))
                    EndTask();
        }
    }

    public void EndTask() {

        taskStarted = false;
        
        if (inventory)
            inventory.SetActive(false);
      
        taskTime = Time.time - taskStartTime;

        if (taskTimeText)
            taskTimeText.text = taskTime.ToString();
    }
}
