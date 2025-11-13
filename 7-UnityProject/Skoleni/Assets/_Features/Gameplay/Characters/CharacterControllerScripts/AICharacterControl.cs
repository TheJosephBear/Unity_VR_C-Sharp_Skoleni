using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AICharacterControl : MonoBehaviour {

    public float StoppingDistanceFromTarget = 1.0f;

    Character _characterComponent;
    Vector3 _targetPosition;


    void Start() {
        _characterComponent = GetComponent<Character>();
    }

    void Update() {
        if (Time.timeScale == 0f) return;

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        SetTargetPosition(player.transform.position);
        HandleMove();
    }

    void HandleMove() {
        Vector2 directionToTarget = new Vector2(
            _targetPosition.x - transform.position.x,
            _targetPosition.z - transform.position.z
        );

        _characterComponent.SetMoveInput(directionToTarget.normalized);
    }

    void SetTargetPosition(Vector3 targetPosition) {
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        _targetPosition = targetPosition - directionToTarget * StoppingDistanceFromTarget;
    }


}
