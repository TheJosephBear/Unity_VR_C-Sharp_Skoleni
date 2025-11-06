using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int ObjectCountToSpawn = 20;
    public List<GameObject> PrefabsToSpawn = new List<GameObject>();
    public Vector3 SpawningPointSize;

    private void Start() {
        for (int i = 0; i < ObjectCountToSpawn; i++) {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject() {
        GameObject objectToSpawn = PrefabsToSpawn[0];

        if (PrefabsToSpawn.Count > 1) {
            objectToSpawn = PrefabsToSpawn[Random.Range(0, PrefabsToSpawn.Count-1)];
        }

        Instantiate(objectToSpawn, PickRandomSpawningPoint(), Quaternion.identity);
    }

    Vector3 PickRandomSpawningPoint() {
        Vector3 spawningPoint = Vector3.zero;

        Vector3 position = transform.position;
        float positionX = Random.Range(position.x - SpawningPointSize.x/2, position.x + SpawningPointSize.x/2);
        float positionY = Random.Range(position.y - SpawningPointSize.y/2, position.y + SpawningPointSize.y/2);
        float positionZ = Random.Range(position.z - SpawningPointSize.z/2, position.z + SpawningPointSize.z/2);
        spawningPoint = new Vector3(positionX, positionY, positionZ);

        return spawningPoint;
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, SpawningPointSize);
    }
}
