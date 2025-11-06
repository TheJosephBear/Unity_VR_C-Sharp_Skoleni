using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        print($"Do zelené kostky vrazil {collision.gameObject.name}");

    }

    private void OnTriggerEnter(Collider other) {
        print($"Do triggerru zelené kostky vlezl {other.name}");
    }
}
