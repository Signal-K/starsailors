using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // used to show when the inventory has changed
using System.Linq;

[System.Serializable]
public class iInventorySystem {
    [SerializeField] private List<InventorySlot> inventorySlots;
    public List<InventorySlot>InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;
    public UnityAction<InventorySlot> OnInventorySlotChanged; // Events that fires when an item is added to the inventory
    public iInventorySystem(int size) { // Takes the size of the system
        inventorySlots = new List<InventorySlot>(size); // a set of slots/inventory like the "player"'s inventory/backpack. Can create multiple versions of this for things like containers
        for (int i = 0; i < size; i++) { // Make enough inventory slots to fill the system based on its desired size
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd) {
        //inventorySlots[0] = new InventorySlot(itemToAdd, amountToAdd);
        if (ContainsItem(itemToAdd, out InventorySlot invSlot)) { // If the data of the picked up object matches the data of an item in one+ of the slots:
            invSlot.AddToStack(amountToAdd); // add the picked up item to the stack in the matching slot ^
            OnInventorySlotChanged?.Invoke(invSlot); // Pass that slot out to any listeners
            return true;
        } else if (HasFreeSlot(out InventorySlot freeSlot)) { // If there's no matching item in the inventory, but if there's a free slot the picked-up item can be placed into - first available slot
            freeSlot = new InventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
        }
    }

    // Check for item stack information in each slot
    public bool ContainsItem(InventoryItemData itemToAdd, out InventorySlot invSlot) { // Is the item being added/picked up in this inventory slot (does the data match? -> if one slot matches, "out"/return that slot)
        invSlot = null;
        return false;
    }

    // Find the first free slot in the holder's inventory system
    public bool HasFreeSlot(out InventorySlot freeSlot) {

    }
}