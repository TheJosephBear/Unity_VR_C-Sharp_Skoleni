using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject EffectPrefab;

    public void ActivateEffect() {
        Instantiate(EffectPrefab, SpawnPoint.position, Quaternion.identity);
    }

}
