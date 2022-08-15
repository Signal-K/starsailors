using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class SelectionManager : MonoBehaviour { // Interactable object documentation: https://skinetics.notion.site/Interactable-Objects-851b3d1289984b769dd01f0a17c244af
    public static SelectionManager Instance { get; set; } // allow `onTarget` to be accessed in `InteractableObject.cs`

    public bool onTarget; // For ensuring the box collider for "add item to inventory" is the object's collider and NOT the range collider of the object
    public GameObject interaction_Info_UI; // referenced in the inspector
    Text interaction_text; // reference to the text component of the GameObject ^^
 
    private void Start() {
        onTarget = false;
        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }

    private void Awake() {
        if (Instance != null && Instance != this) { // Prevent multiple SelectionManagers from being instantiated
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
 
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Send a ray to the MIDDLE of the screen
        RaycastHit hit; // information from the raycast
        if (Physics.Raycast(ray, out hit)) { // check if the ray[cast] has hit a gameobject
            var selectionTransform = hit.transform; // transform component of the object that the ray hit
            InteractableObject ourInteractable = selectionTransform.GetComponent<InteractableObject>();

            if (ourInteractable && ourInteractable.playerInRange) { // Check if the rayhit is something that should be interacted with (e.g. sky shouldn't be interactable by default)
                onTarget = true; // the cursor for adding item to inventory is on the correct collider of the object
                interaction_text.text = ourInteractable.GetItemName(); // fill the text with the item name
                interaction_Info_UI.SetActive(true); // display the item text to the scene
            } else  { // do not display the text if the raycast hit is true but the item is not interactable
                onTarget = false;
                interaction_Info_UI.SetActive(false);
            }
        } else { // if raycast isn't hitting anything
            onTarget = false;
            interaction_Info_UI.SetActive(false); // could have also fixed the bug by ensuring that the next raycast matches the getItemName component, or else reset the text, but this is faster
        }
    }
}