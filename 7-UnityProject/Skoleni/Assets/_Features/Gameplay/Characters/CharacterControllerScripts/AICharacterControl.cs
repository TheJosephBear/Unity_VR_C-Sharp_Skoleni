using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AICharacterControl : MonoBehaviour {

    public float StoppingDistanceFromTarget = 1.0f;
    public float AttackingDistanceFromTarget = 1.0f;

    Character _characterComponent;
    Vector3 _targetPosition;


    void Start() {
        _characterComponent = GetComponent<Character>();

        InvokeRepeating("TryAttack", 0f, 1f);
    }

    void Update() {
        if (Time.timeScale == 0f) return;

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        SetTargetPosition(player.transform.position);
        HandleMove();
    }

    void TryAttack() {
        if (Vector3.Distance(_targetPosition, transform.position) <= AttackingDistanceFromTarget){
            _characterComponent.PerformAttack();
        }
    }

    void HandleMove() {
        Vector3 worldDirection = _targetPosition - transform.position;

        // Convert to local space (relative to character's forward) 
        Vector3 localDirection = transform.InverseTransformDirection(worldDirection);

        // Vector3 -> 2
        Vector2 moveInput = new Vector2(localDirection.x, localDirection.z);

        _characterComponent.SetMoveInput(moveInput.normalized);
    }

    void SetTargetPosition(Vector3 targetPosition) {
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        _targetPosition = targetPosition - directionToTarget * StoppingDistanceFromTarget;
    }
}
