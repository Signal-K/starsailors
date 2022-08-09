using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class iItemPickup : MonoBehaviour {
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;
    private SphereCollider myCollider;

    private void Awake() {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }

    private void OnTriggerEnter(Collider other) {
        var inventory = other.transform.GetComponent<InventoryHolder>();
        if (!inventory) return; // If the object hasn't collided with an object that has an inventory (like the player)
        if (inventory.iInventorySystem.AddToInventory(ItemData, 1)) { // add 1 of the item
            Destroy(this.gameObject); // If the object/item is added to the inventory holder/system, remove it from the game scene/hierarchy
        }
    }
}