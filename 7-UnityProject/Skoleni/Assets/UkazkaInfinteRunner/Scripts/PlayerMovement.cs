using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float _movementSpeed = 2f;

    public float MaxDistanceFromCenter = 2.5f;

    int _score = 0;

    void Start() {

    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Get axis horizontal jako alternativa k tomuto kódu:
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            horizontalInput = -1f;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) { 
            horizontalInput = 1f;
        } else { 
            horizontalInput = 0; 
        }
        */

        float newZ = transform.position.z + horizontalInput * _movementSpeed * Time.deltaTime;
        newZ = Mathf.Clamp(newZ, -MaxDistanceFromCenter, MaxDistanceFromCenter);

        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);


    }

    public void IncreaseScore(int scoreIncrease = 1) {
        _score += scoreIncrease;
        print("Score: " + _score);
    }

}
