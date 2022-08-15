using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour {
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot assignedInventorySlot; // backend slot -> represented by this UI object

    private Button button;
    public InventorySlot AssignedInventorySlot => assignedInventorySlot;
    public InventoryDisplay ParentDisplay { get; private set; }

    private void Awake() {
        ClearSlot();
        button.GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlot slot) {
        assignedInventorySlot = slot; // equal to slot passed in
        UpdateUISlot(slot); // pass this into the UI
    }

    public void UpdateUISlot(InventorySlot slot) {
        if (slot.ItemData != null) {
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;
            if (slot.StackSize > 1) itemCount.text = slot.StackSize.ToString(); // display the number of icons in a slot when the number of items in the slot > 1
            else itemCount.text = "";
        } else {
            ClearSlot(); // if a slot that has no data/item has been passed in
        }
    }

    public void UpdateUISlot() {
        if (assignedInventorySlot != null) UpdateUISlot(assignedInventorySlot); // Refresh the slot without passing in a specific slot
    }

    public void ClearSlot() { // Set the specified inventory slot's state back to nul/default
        assignedInventorySlot?.ClearSlot(); // if null, clear this slot (ui match system)
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void OnUISlotClick() {
        ParentDisplay?.SlotClicked(this); // Access display class function
    }
}