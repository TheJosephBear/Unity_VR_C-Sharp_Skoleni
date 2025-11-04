using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float MovementSpeed;
    public Vector3 MovementDirection;

    Rigidbody _rb;

    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        _rb.AddForce(MovementDirection * MovementSpeed, ForceMode.Force);

        //   _rb.MovePosition(transform.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            print("Player has received a coin!");
            collision.gameObject.GetComponent<PlayerMovement>().IncreaseScore() ;
        }
    }

}
