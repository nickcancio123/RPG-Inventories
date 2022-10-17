using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    // Tabs
    [SerializeField] int defaultTabOpen = 0;
    [SerializeField] protected List<Tab> tabs;

    // Hovering over items
    ItemSlot hoveredItemSlot;

    // Grabbing items
    [SerializeField] Image grabbedItemImage;
    [SerializeField] Vector2 grabbedItemImageOffset;

    bool grabbingItem = false;

    Item_SO grabbedItem;
    ItemSlot grabbedItemOriginalSlot;



    protected virtual void Start() {
        OpenTab(tabs[defaultTabOpen]);
    }

    protected void OnEnable() {

        // Listen for item slot hover
        for (int t = 0; t < tabs.Count; t++) {
            for (int i = 0; i < tabs[t].itemSlots.Count; i++) {
                tabs[t].itemSlots[i].hoverEvent += NewItemHovered;
            }
        }
    }

    protected void OnDisable() {

        // Stop listen for item slot hover
        for (int t = 0; t < tabs.Count; t++) {
            for (int i = 0; i < tabs[t].itemSlots.Count; i++) {
                tabs[t].itemSlots[i].hoverEvent -= NewItemHovered;
            }
        }
    }

    protected void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0))
            GrabItem();
      
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
            DropItem();
        
        UpdateGrabbedItemImage();
    }


    public void OpenTab(Tab callingTab) {
        for (int i = 0; i < tabs.Count; i++) {
            bool open = callingTab == tabs[i];
            tabs[i].OpenCloseTab(open);
        }
    }


    protected virtual void NewItemHovered(ItemSlot _hoveredItemSlot) {
        hoveredItemSlot = _hoveredItemSlot;
    }


    public void GrabItem() {

        if (grabbingItem)
            return;

        if (hoveredItemSlot == null) {
            Debug.Log("No hover item");
            return;
        }

        if (hoveredItemSlot.GetItemType() == null) {
            grabbedItemImage.sprite = null;
            return;
        }

        grabbingItem = true;

        grabbedItemOriginalSlot = hoveredItemSlot;
        grabbedItem = hoveredItemSlot.GetItemType();

        grabbedItemImage.sprite = grabbedItem.icon;

        hoveredItemSlot.SetItemType(null);
    }
    private void DropItem() {
        if (!grabbingItem)
            return;

        grabbingItem = false;

        grabbedItemImage.sprite = null;

        grabbedItemOriginalSlot.SetItemType(hoveredItemSlot.GetItemType());
        hoveredItemSlot.SetItemType(grabbedItem);

        NewItemHovered(hoveredItemSlot);
        
        grabbedItem = null;
        grabbedItemOriginalSlot = null;
    }
    void UpdateGrabbedItemImage() {
        grabbedItemImage.color =  new Color(1, 1, 1, grabbingItem ? 1 : 0);

        Vector2 mousePosRel = transform.InverseTransformVector(Input.mousePosition);
        grabbedItemImage.transform.position = mousePosRel + grabbedItemImageOffset;
    }

}