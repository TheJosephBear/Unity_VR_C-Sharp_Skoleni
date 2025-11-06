using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kostka : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        print($"Do fialové kostky vrazil {collision.gameObject.name}");

    }

    private void OnTriggerEnter(Collider other) {
        print($"Do triggerru fialové kostky vlezl {other.name}");
    }
}
