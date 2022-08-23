using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler { // drag an item across the inventory screen
    //[SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup; // When clicking on the item, separate the item from the rest of the UI/canvas e.g. inventory slot

    public static GameObject itemBeingDragged; // inventory item inside an inventory slot
    Vector3 startPosition;
    Transform startParent; // What was the original slot the item was in

    private void Awake() {
        //Canvas = ReferenceManager.instance.getCanvasReference(); // If we were to change the scale of the canvas, we'd need to add a singleton in the hierarchy that references all of the UI, including the canvas which is placed on it
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>(); // Also avoid interfering with the ray[cast]
    }

    public void OnBeginDrag(PointerEventData eventData) { // User stats dragging an item
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false; // ray cast will ignore item + inventory/2d canvas ui
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(transform.root); // while the object is being dragged, it becomes a child of the `InventoryScreen` object and not the slot
        itemBeingDragged = gameObject;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta; // Item will move with the mouse at same speed. Consistent movement independant of canvas scale
    }

    public void OnEndDrag(PointerEventData eventData) { // When user lifts finger off mouse from drag action/motion
        itemBeingDragged = null;
        
        if (transform.parent == startParent || transform.parent == transform.root) {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}