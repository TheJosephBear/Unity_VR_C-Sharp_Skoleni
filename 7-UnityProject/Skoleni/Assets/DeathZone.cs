using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    public Transform StartPoint;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            /*  CharacterController cc = other.GetComponent<CharacterController>();
              cc.enabled = false;
              other.transform.position = StartPoint.position;
              cc.enabled = true;*/

            SceneManager.LoadScene("MainScene");
        }
    }
}
