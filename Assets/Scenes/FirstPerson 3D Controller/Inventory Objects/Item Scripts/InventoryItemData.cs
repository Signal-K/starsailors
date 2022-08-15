using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class InventoryItemData : ScriptableObject {
    public int ID; // item id
    public string DisplayName;
    [TextArea(4, 4)]
    public string Description;
    public Sprite Icon; // sprite icon for the item
    public int MaxStackSize; // different items will have different stack sizes   
}