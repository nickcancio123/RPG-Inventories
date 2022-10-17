using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField] GameObject handle;
    [SerializeField] Image handleImage;
    [SerializeField] GameObject body;

    [SerializeField] Color openHandleColor;
    [SerializeField] Color closedHandleColor;

    public List<ItemSlot> itemSlots;

    bool IsOpen;


    public void OpenCloseTab(bool open) {
        body.SetActive(open);
        handleImage.color = open ? openHandleColor : closedHandleColor;
    }
}
