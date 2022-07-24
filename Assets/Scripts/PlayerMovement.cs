using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // check to see if player hit the ground (reset falling velocity)
        if (isGrounded && velocity.y < 0) {
            velocity.y = 2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded) { // Check if player is on ground to jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // jump equation
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}