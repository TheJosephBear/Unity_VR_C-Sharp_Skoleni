using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAttack : MonoBehaviour, IAttack {

    public float SpeedMultiplier = 4f;
    public int Damage = 150;
    public float SpellDuration = 150;

    Character _characterScript;
    float _originalSpeed;
    bool _spellActive = false;

    void Awake() {
        _characterScript = GetComponent<Character>();
    }

    public void ExecuteAttack() {
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine() {
        _spellActive = true;
        _originalSpeed = _characterScript.GetMovementSpeed();
        _characterScript.SetMovementSpeed(_originalSpeed * SpeedMultiplier);

        yield return new WaitForSeconds(SpellDuration);
        _characterScript.SetMovementSpeed(_originalSpeed);
        _spellActive = false;
    }

    // Character controller nemá rigidbody - negeneruje oncollision
    private void OnControllerColliderHit(ControllerColliderHit collision) {
        if (!_spellActive) return;

        IDamageable hit = collision.gameObject.GetComponent<IDamageable>();
        if (hit == null) return;

        hit.TakeDamage(Damage);
    }

}
