using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This can be placed on gameObjects or prefabs
public class InteractableObject : MonoBehaviour {
    public string ItemName;
    public string GetItemName() {
        return ItemName;
    }
}