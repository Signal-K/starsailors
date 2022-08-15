using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class pPlayerMovement : MonoBehaviour {
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    //private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    // Player controls input system
    private PlayerControls playerControls;

    private void Awake() {
        controller = gameObject.GetComponent<CharacterController>();
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls?.Enable(); // if it isn't null, enable
    }

    private void OnDisable() {
        playerControls?.Disable();
    }

    void Update() {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(playerControls.Player.Movement.ReadValue<Vector2>().x, 0, playerControls.Player.Movement.ReadValue<Vector2>().y); // not using Input.GetAxis as this script is using the new Unity input system
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }

        /*if (Input.GetButtonDown("Jump") && groundedPlayer) { // Change the height position of the player
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f & gravityValue);
        }*/

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}