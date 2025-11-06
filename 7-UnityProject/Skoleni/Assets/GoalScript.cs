using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    public GameObject ParticleEffectRefference;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            print("Enemy hit the goal!");

            Instantiate(ParticleEffectRefference, transform.position, Quaternion.identity);
        }
    }
}
    