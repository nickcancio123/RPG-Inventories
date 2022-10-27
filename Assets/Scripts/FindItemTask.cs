using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindItemTask : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] PlayerEquipment playerEquipment;
    [SerializeField] Item_SO targetItemType;

    [Header("Task UI")]
    [SerializeField] GameObject preTaskUI;
    [SerializeField] GameObject postTaskUI;

    [SerializeField] TMP_Text taskTimeText;
    [SerializeField] TMP_Text targetItemNameText;


    float taskTime = 0;
    float taskStartTime = 0;

    bool taskStarted = false;


    void Start() {
        inventory.gameObject.SetActive(false);
        postTaskUI.SetActive(false);

        preTaskUI.SetActive(true);

        targetItemNameText.text = targetItemType.itemName;
    }

    public void StartTask() {
        taskTime = 0;
        taskStartTime = Time.time;
        taskStarted = true;

        preTaskUI.SetActive(false);
        inventory.SetActive(true);
    }

    void Update() {

        if (taskStarted)
            if (playerEquipment.IsItemTypeEquipped(targetItemType))
                EndTask();
    }

    public void EndTask() {

        taskStarted = false;
        
        inventory.SetActive(false);
        postTaskUI.SetActive(true);

        taskTime = Time.time - taskStartTime;
        taskTime = Mathf.Round(taskTime * 100) / 100;
        taskTimeText.text = taskTime.ToString();
    }
}
