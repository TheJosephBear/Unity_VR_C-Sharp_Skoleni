using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float MovementSpeed = 5f;

    GameObject _target;
    CharacterController _characterController;

    void Start() {
        _characterController = GetComponent<CharacterController>();
        _target = GameObject.FindWithTag("Finish");
    }

    void Update() {
        if (_characterController != null) {
            Vector3 newPosition = Vector3.MoveTowards(
                 transform.position,
                 _target.transform.position,
                 MovementSpeed * Time.deltaTime
             );
            Vector3 movementVector = newPosition - transform.position;

            // character controller oèekává vektor pohybu, ne novou pozici;
            _characterController.Move(movementVector);

            /* TELEPORTACE S CHARACTER CONTROLLER */
            CharacterController controller = GetComponent<CharacterController>();
            controller.enabled = false;
            transform.position = new Vector3(0, 0, 0); // pozice kam chci teleportovat
            controller.enabled = true;

        } else {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, MovementSpeed * Time.deltaTime);
        }
    }


}
