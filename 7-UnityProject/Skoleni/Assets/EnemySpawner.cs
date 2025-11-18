using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Header("Settings")]
    public int WaveCount = 3;
    public int WaveEnemyCount = 5;
    public float TimeBetweenWaves = 3f;
    public float TimeBetweenSpawns = 0.5f;

    [Header("Refferences")]
    public Transform SpawnPointReff;
    public List<GameObject> CharacterPrefabList = new List<GameObject>();
    public GameObject BossPrefab;

    List<GameObject> _spawnedEnemies = new List<GameObject>();

    public void StartSpawning() {

    }

    public void DestroyAllEnemies() {
        foreach (GameObject enemy in _spawnedEnemies) {
            Destroy(enemy);
        }

        _spawnedEnemies.Clear();
    }

    void SpawnRandomEnemy() {

    }

}
