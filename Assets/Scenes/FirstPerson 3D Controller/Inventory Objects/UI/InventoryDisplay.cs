using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour {
    [SerializeField] MouseItemData mouseInventoryItem;
    protected InventorySystem inventorySystem; // The inventory system that is being displayed now
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary; // match the UI slot with the system's slot
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start() {

    }
    
    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlot updatedSlot) { // Pass in the system slot (InventorySlot.cs) to the UI slot
        foreach (var slot in slotDictionary) { // loop through all the slots to see if the slot value matches the value passed in from the system
            if (slot.Value == updatedSlot) {
                slot.Key.UpdateUISlot(updatedSlot);
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedSlot) {
        Debug.Log("Slot clicked");
    }
}