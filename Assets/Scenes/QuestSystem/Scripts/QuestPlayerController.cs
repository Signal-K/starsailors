using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayerController : MonoBehaviour {
    public float questPlayerSpeed;
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += input.normalized * questPlayerSpeed * Time.deltaTime;

        if (input != Vector3.zero) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
    }
}