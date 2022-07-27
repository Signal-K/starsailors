using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController controller;

    public float speed = 12f; // player movement velocity
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck; // check if the player is standing on the ground (this is used for the jumping mechanic)
    public float groundDistance = 0.4f; // distance between groundCheck and ground
    public LayerMask groundMask;

    Vector3 velocity; // Velocity of the player's fall

    bool isGrounded;

    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // check to see if player hit the ground (reset falling velocity)
        if (isGrounded && velocity.y < 0) { // if the player hasn't hit the ground, next frame the fall speed will be doubled (increase)
            velocity.y = -2f;
        }

        // Check player input x & y (wasd/arrow key input)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // place the player input into the movement function
        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded) { // Check if player is on ground to jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // jump equation
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}