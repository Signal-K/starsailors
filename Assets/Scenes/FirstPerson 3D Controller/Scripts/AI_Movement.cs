using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Movement : MonoBehaviour {
    Animator animator;
    public float moveSpeed = 0.2f;
    Vector3 stopPosition; // transform -> where did the object/prefab stop?
    float walkTime; // time the prefab/ai will walk
    public float walkCounter;
    float waitTime;
    public float waitCounter;
    int WalkDirection;
    public bool isWalking;

    void Start() {
        animator = GetComponent<Animator>(); // ref to Animator component of the gameObject [this script is attached to]

        // Prevent all the prefabs from moving/stopping at the same time
        walkTime = Random.Range(3, 6); // between in seconds
        waitTime = Random.Range(5, 7);
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }

    void Update() {
        if (isWalking) {
            animator.SetBool("isRunning", true); // local animator bool/param
            walkCounter -= Time.deltaTime;
            switch (WalkDirection) {
                case 0:
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 1:
                    transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 2:
                    transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 3:
                    transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
            }

            if (walkCounter <= 0) { // Counts down from walkTime until gets to 0, then stops the prefab/ai and resets
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;
                // stop movement
                transform.position = stopPosition;
                animator.SetBool("isRunning", false);
                // reset the waitCounter
                waitCounter = waitTime;
            }
        } else {
            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0) {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection() {
        WalkDirection = Random.Range(0, 4); // 0, 1, 2, or 3 -> nesw
        isWalking = true;
        walkCounter = walkTime;
    }
}