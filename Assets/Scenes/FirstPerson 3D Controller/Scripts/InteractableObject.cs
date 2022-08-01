using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This can be placed on gameObjects or prefabs
public class InteractableObject : MonoBehaviour {
    public bool playerInRange; // For determining when to show the UI -> when the player is in range of an object the raycast hits (see SelectionManager.cs)

    public string ItemName;
    public string GetItemName() {
        return ItemName;
    }

    private void Update() {
        // Click/input action from player for picking up items
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange) { // if left button pressed and the player is in range and raycast is on the object's box collider (not range box collider)
            Debug.Log("Item added to inventory");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerInRange = true; // If the player enters into an area it collides with the interactable object's range collider
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
        }
    }
}