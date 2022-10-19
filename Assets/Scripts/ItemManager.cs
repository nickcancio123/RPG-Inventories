using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<ItemContainer> containers;

    [SerializeField] Image grabbedItemImage;
    [SerializeField] Vector2 grabbedItemImageOffset;

    [SerializeField] Camera cam;
    [SerializeField] Canvas canvas;

    [SerializeField] float mousePosScaleFactor = 1.925f;

    bool grabbingItem = false;
    Item_SO grabbedItem;
    ItemSlot grabbedItemOriginalSlot;


    protected void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0))
            GrabItem();

        if (Input.GetKeyUp(KeyCode.Mouse0))
            DropItem();

        UpdateGrabbedItemImage();
    }

    // Grabbing
    public void GrabItem() {

        if (grabbingItem)
            return;

        ItemSlot hoveredSlot = GetHoveredSlot();
        if (hoveredSlot == null) {
            return;
        }

        if (hoveredSlot.GetItemType() == null) {
            grabbedItemImage.sprite = null;
            return;
        }

        grabbingItem = true;

        grabbedItemOriginalSlot = hoveredSlot;
        grabbedItem = hoveredSlot.GetItemType();

        grabbedItemImage.sprite = grabbedItem.icon;
    }
    private void DropItem() {
        if (!grabbingItem)
            return;

        grabbingItem = false;

        ItemSlot hoveredSlot = GetHoveredSlot();
        if (hoveredSlot == null) 
            return;

        grabbedItemImage.sprite = null;

        Item_SO hoveredSlotItem = hoveredSlot.GetItemType();
        bool dropSuccess = hoveredSlot.SetItemType(grabbedItem);
        if (dropSuccess)
            grabbedItemOriginalSlot.SetItemType(hoveredSlotItem);

        grabbedItem = null;
        grabbedItemOriginalSlot = null;
    }
    void UpdateGrabbedItemImage() {
        grabbedItemImage.color = new Color(1, 1, 1, grabbingItem ? 1 : 0);

        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 mousePosRel = cam.ScreenToWorldPoint(mouseScreenPos) * mousePosScaleFactor;
        Vector3 targetPos = mousePosRel + grabbedItemImageOffset;
        grabbedItemImage.rectTransform.localPosition = targetPos;
    }


    ItemSlot GetHoveredSlot() {
        for (int i = 0; i < containers.Count; i++) {
            if (containers[i].IsHoveringOverContainer())
                return containers[i].GetHoveredSlot();
        }
        return null;
    }

}
