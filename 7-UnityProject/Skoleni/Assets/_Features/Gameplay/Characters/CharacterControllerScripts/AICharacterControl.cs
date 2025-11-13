using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AICharacterControl : MonoBehaviour {

    public float StopDistanceFromTarget = 3f;
    public float AttackDistance = 3f;
    public float AttackCoolDown = 1.5f;

    Character characterComponent;
    Vector3 _targetPosition;

    void Start() {
        characterComponent = GetComponent<Character>();

        //    SetTargetPosition(new Vector3(4, 0, 4));
        InvokeRepeating("TryAttack", 0f, AttackCoolDown);
    }

    void Update() {
        if (Time.timeScale == 0f) return;

        GameObject player = GameObject.FindWithTag("Player");
        if(player == null) return;

        SetTargetPosition(player.transform.position);
        HandleMove();
    }

    void TryAttack() {
        if (Vector3.Distance(transform.position, _targetPosition) <= AttackDistance) {
            characterComponent.PerformAttack();
        }
    }

    void HandleMove() {
        Vector3 worldDirection = _targetPosition - transform.position;
        // Convert to local space (relative to character's forward)
        Vector3 localDirection = transform.InverseTransformDirection(worldDirection);
        // Vector3 -> 2
        Vector2 moveInput = new Vector2(localDirection.x, localDirection.z);

        characterComponent.SetMoveInput(moveInput.normalized);
    }

    void SetTargetPosition(Vector3 targetPosition) {
        Vector3 direction = targetPosition - transform.position;

        _targetPosition = targetPosition - direction.normalized * AttackDistance;
    }

}
