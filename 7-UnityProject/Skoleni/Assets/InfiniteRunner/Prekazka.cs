using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prekazka : MonoBehaviour
{
    public float speed = 3f;          
    public Vector3 direction = Vector3.right;  

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.MovePosition(transform.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Hit the player!");
        }
    }
}
