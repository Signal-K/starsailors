using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour {
    public static InventorySystem Instance { get; set; } // singleton for later use
    public GameObject inventoryScreenUI;
    public List<GameObject> slotList = new List<GameObject>(); // Contains all the slots - not the items in the slots. Used to identify which slots are filled (and later, by how many items)
    public List<string> itemList = new List<string>();
    private GameObject itemToAdd;
    private GameObject slotToEquip;
    public bool isOpen;
    public bool isFull; // Are all of the inventory slots filled?

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    void Start() {
        isOpen = false; // By default, the inventory screen ui is not open/active when the scene starts
        PopulateSlotList();
    }

    private void PopulateSlotList() {
        foreach (Transform child in inventoryScreenUI.transform) { // Transform elements inside the inventory canvas
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I) && !isOpen) { // if the inventory screen isn't currently open
            Debug.Log("Inventory hotkey is pressed");
            inventoryScreenUI.SetActive(true); // Display the inventory screen as an active game object in scene
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
        } else if (Input.GetKeyDown(KeyCode.I) && isOpen) {
            inventoryScreenUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            isOpen = false; // The inventory screen is no longer visible
        }
    }
}