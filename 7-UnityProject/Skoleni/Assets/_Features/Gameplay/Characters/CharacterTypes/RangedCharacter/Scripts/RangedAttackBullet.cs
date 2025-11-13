using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackBullet : MonoBehaviour {

    public GameObject ParticleEffectPrefab;
    float _speed;
    int _damage;

    public void Initialize(float speed, int damage) {
        _speed = speed;
        _damage = damage;
    }

    void Update() {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null) {
            damageable.TakeDamage(_damage);
        }
        Explode();
    }

    void Explode() {
        Instantiate(ParticleEffectPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

 }
