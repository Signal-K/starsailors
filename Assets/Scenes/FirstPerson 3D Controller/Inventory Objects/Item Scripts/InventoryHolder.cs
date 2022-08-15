using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour {
    [SerializeField] private int inventorySize;
    [SerializeField] protected iInventorySystem inventorySystem;
    public iInventorySystem iInventorySystem => inventorySystem; // getter
    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    private void Awake() {
        inventorySystem = new iInventorySystem(inventorySize);
    }
}