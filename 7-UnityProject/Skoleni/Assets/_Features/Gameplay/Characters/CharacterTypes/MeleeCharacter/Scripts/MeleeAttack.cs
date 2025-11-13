using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttack {

    public GameObject EffectPrefab;

    [Header("Attack Settings")]
    public int Damage = 10;
    public Vector3 BoxSize = new Vector3(1f, 1f, 1f);
    public Vector3 Offset = new Vector3(0, 0, 1f);

    [Header("Gizmo Settings")]
    public bool DrawGizmo = true;
    public Color GizmoColor = Color.red;

    public void ExecuteAttack() {
        Instantiate(EffectPrefab, transform).transform.position += transform.forward * 0.5f;

        Vector3 boxCenter = transform.position + transform.TransformDirection(Offset);

        Collider[] hits = Physics.OverlapBox(boxCenter, BoxSize * 0.5f, transform.rotation);
        foreach (Collider hit in hits) {
            IDamageable damageable = hit.GetComponent<IDamageable>();
            if (damageable != null) {
                // dont hit yourself
                if (hit.gameObject.GetInstanceID() == this.gameObject.GetInstanceID()) {
                    continue;
                }

                OnHit(damageable);
            }
        }
    }

    void OnHit(IDamageable hitObject) {
        hitObject.TakeDamage(Damage);
    }


    private void OnDrawGizmosSelected() {
        if (!DrawGizmo) return;

        Gizmos.color = GizmoColor;
        Vector3 boxCenter = transform.position + transform.TransformDirection(Offset);
        Gizmos.matrix = Matrix4x4.TRS(boxCenter, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, BoxSize);
    }

}
