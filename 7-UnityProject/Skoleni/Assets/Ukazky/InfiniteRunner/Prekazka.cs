using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prekazka : MonoBehaviour {
    [HideInInspector]
    public float speed;
    public Vector3 direction = Vector3.right;

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.MovePosition(transform.position + direction.normalized * speed * Time.fixedDeltaTime);
    }
}
