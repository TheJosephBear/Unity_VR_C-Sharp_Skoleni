using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfiniteRunner : MonoBehaviour {

    public List<float> MovePositions = new List<float>(); // x-osa pro úhyby
    public GameObject PlayerObject;

    int _currPosition = 1;

    void Start() {
        PlayerObject.transform.position = new Vector3(MovePositions[1], PlayerObject.transform.position.y, PlayerObject.transform.position.z);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Move(-1);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Move(1);
        }
    }

    void Move(int move) {
        if (!(_currPosition + move >= 0 && _currPosition + move <= 2)) return;

        _currPosition += move;
        PlayerObject.transform.position = new Vector3(MovePositions[_currPosition], PlayerObject.transform.position.y, PlayerObject.transform.position.z);
    }

    void Death() {
        Time.timeScale = 0;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Prekazka")) {
            Death();
        }
    }



}
