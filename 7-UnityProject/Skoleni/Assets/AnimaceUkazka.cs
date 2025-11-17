using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaceUkazka : MonoBehaviour {
    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();


    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            animator.SetBool("walk", true);
        } else {
            animator.SetBool("walk", false);
        }
    }

}
