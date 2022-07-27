using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {
    public float mouseSensetivity = 100f; // mouse input is multiplied by the sensitivity (can be set in game)
    float xRotation = 0f; // controlling rotation around the x axis (camera view rotate)
    float yRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to middle of the screen
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime; // input of the x axis of the mouse, configured slightly based on params
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime; // deltaTime -> input based on time since last frame
        xRotation -= mouseY; // control rotation around x axis (up and down)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp camera rotation movement to prevent looking around in a non-humanoid manner (can be changed later for aliens/with new skills)
        yRotation += mouseX; // control rotation around y axis -> look up and down
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); // apply both rotations
    }
}