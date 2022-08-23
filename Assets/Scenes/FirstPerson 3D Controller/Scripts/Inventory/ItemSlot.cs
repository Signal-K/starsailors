using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {
    public GameObject Item {
        get {
            if (transform.childCount > 0) {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");

        if (!Item) { // If there is no item in the slot, set this item
            DragDrop.itemBeingDragged.transform.SetParent(transform); // Update this statement so that multiple items of the same type can be added onto a single slot -> GetComponent name (search for e.g. "stone")
            DragDrop.itemBeingDragged.transform.localPosition = new Vector2(0, 0);
        }
    }
}