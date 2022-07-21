using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    void Update() { // Update is called once per frame
        if (Input.GetMouseButtonDown(0)) { // Was the mouse pressed down this frame?
            Camera theCamera = Camera.main;
            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray)) {
                //Debug.Log("Hit game object: " + hitInfo.collider.gameObject.name);
            }
        }
    }
}
