using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour, IAttack {

    [Range(0, 10f)]
    public float Duration = 1f;
    [Range(0, 10f)]
    public float Strength = 1f;
    [Range(0, 10f)]
    public float CooldownTime = 2f;

    Character _character;
    float _nextAttackTime = 0f;

    void Awake() {
        _character = GetComponent<Character>();
    }

    public void ExecuteAttack() {
        if (Time.time >= _nextAttackTime && _character.IsGrounded()) {
            _character.DisableGravityForDuration(Duration, Strength);

            _nextAttackTime = Time.time + CooldownTime;
        }
    }
}
