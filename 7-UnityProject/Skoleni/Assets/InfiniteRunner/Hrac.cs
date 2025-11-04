using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hrac : MonoBehaviour
{
    public float moveSpeed = 5f;             
    public float maxDistanceFromStart = 5f;  

    private float startZ;

    void Start() {
        startZ = transform.position.x;  
    }

    void Update() {
        float input = Input.GetAxis("Horizontal");
        float move = input * moveSpeed * Time.deltaTime;

        float newZ = Mathf.Clamp(transform.position.z + move, startZ - maxDistanceFromStart, startZ + maxDistanceFromStart);

        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
