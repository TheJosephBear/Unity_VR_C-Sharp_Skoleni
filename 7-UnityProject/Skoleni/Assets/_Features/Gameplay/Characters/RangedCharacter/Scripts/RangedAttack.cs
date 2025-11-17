using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangedAttack : MonoBehaviour, IAttack {

    public int BulletDamage = 20;
    public float BulletSpeed = 1f;

    public GameObject BulletPrefab;
    public Vector3 BulletSpawnOffset;
    public AudioClip CastSound;

    public void ExecuteAttack() {
        RangedAttackBullet bulletScript = Instantiate(BulletPrefab, transform.position + transform.rotation * BulletSpawnOffset, transform.rotation).GetComponent<RangedAttackBullet>();
        bulletScript.Initialize(BulletSpeed, BulletDamage);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Vector3 boxCenter = transform.position + BulletSpawnOffset;
        Gizmos.matrix = Matrix4x4.TRS(boxCenter, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(0.2f, 0.2f, 0.2f));
    }

}
