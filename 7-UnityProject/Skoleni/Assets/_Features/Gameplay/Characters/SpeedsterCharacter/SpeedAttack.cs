using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAttack : MonoBehaviour, IAttack {

    public float AttackDuration = 3f;
    public float SpeedMultipier = 2.5f;
    public int AttackDamage = 80;
    public float CooldownTime = 0.2f;

    public GameObject HitEffectPrefab;

    Character _characterScript;
    float _originalSpeed;
    float _nextAttackTime = 0f;
    bool _attackActive = false;

    private void Awake() {
        _characterScript = GetComponent<Character>();
    }

    public void ExecuteAttack() {
        if (_attackActive) return;

        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine() {
        _attackActive = true;
        // Zvednul rychlost
        _originalSpeed = _characterScript.MoveSpeed;
        _characterScript.MoveSpeed *= SpeedMultipier;

        // Nìjakou dobu to trvá
        yield return new WaitForSeconds(1f);

        // Vrátil pùvodní rychlost
        _characterScript.MoveSpeed = _originalSpeed;
        _attackActive = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit collider) {
        if (!_attackActive  || Time.time <= _nextAttackTime) return;

        IDamageable damageableScript = collider.gameObject.GetComponent<IDamageable>();
        if (damageableScript == null) return;

        Instantiate(HitEffectPrefab, transform.position, Quaternion.identity);
        damageableScript.TakeDamage(AttackDamage);
        _nextAttackTime = Time.time + CooldownTime;
    }

}
