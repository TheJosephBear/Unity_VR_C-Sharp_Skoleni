using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // --- Configuration ---
    public int NumberOfWaves = 3;
    public float TimeBetweenWaves = 5f; // Time delay between waves
    public float TimeBetweenEnemies = 0.5f; // Time delay between spawning individual enemies
    public int BaseEnemiesPerWave = 5; // Starting number of enemies per wave
    public float EnemyCountMultiplier = 1.5f; // Multiplier for enemy count on subsequent waves

    public GameObject BossPrefab;
    public List<GameObject> EnemyCharacterPrefabs = new List<GameObject>();
    public Transform SpawnPoint;

    private int currentWave = 0;
    private bool isSpawning = false;
    List<GameObject> _enemiesSpawned = new List<GameObject>();

    /// <summary>
    /// Public method to initiate the wave spawning process.
    /// </summary>
    public void StartWaveSpawn() {
        if (!isSpawning) {
            currentWave = 0;
            StartCoroutine(WaveSpawnSequence());
        }
    }

    public void DeleteAllEnemies() {
        foreach (var e in _enemiesSpawned) {
            Destroy(e.gameObject);
        }
        _enemiesSpawned.Clear();
    }

    /// <summary>
    /// Coroutine to handle the entire wave sequence, including boss.
    /// </summary>
    private IEnumerator WaveSpawnSequence() {
        isSpawning = true;
        Debug.Log("Starting wave spawn sequence...");

        // Loop through all defined waves
        while (currentWave < NumberOfWaves) {
            currentWave++;
            Debug.Log($"Starting Wave {currentWave}...");

            // 1. Wait for the inter-wave delay
            yield return new WaitForSeconds(TimeBetweenWaves);

            // 2. Spawn the current wave
            yield return StartCoroutine(SpawnWave());

            // 3. (Optional) Wait until all enemies from the wave are defeated
            //    This requires external tracking (e.g., counting active enemies).
            //    For simplicity, this example just proceeds after the wave is spawned.
        }

        Debug.Log("All waves completed. Preparing for boss spawn.");

        // 4. Spawn the Boss after all waves are done
        SpawnBoss();
        isSpawning = false;
    }

    /// <summary>
    /// Coroutine to spawn enemies for the current wave.
    /// </summary>
    private IEnumerator SpawnWave() {
        // Calculate the number of enemies for this wave
        // Example: Wave 1 (5), Wave 2 (5 * 1.5 = 7.5 -> 7), Wave 3 (7.5 * 1.5 = 11.25 -> 11)
        int enemiesToSpawn = Mathf.FloorToInt(BaseEnemiesPerWave * Mathf.Pow(EnemyCountMultiplier, currentWave - 1));

        Debug.Log($"Wave {currentWave}: Spawning {enemiesToSpawn} enemies.");

        for (int i = 0; i < enemiesToSpawn; i++) {
            // Spawn an individual enemy
            SpawnEnemy();
            // Wait for the delay before spawning the next enemy
            yield return new WaitForSeconds(TimeBetweenEnemies);
        }
    }

    /// <summary>
    /// Spawns the boss character.
    /// </summary>
    public void SpawnBoss() {
        if (BossPrefab != null && SpawnPoint != null) {
            Debug.Log("Spawning Boss!");
            _enemiesSpawned.Add(Instantiate(BossPrefab, SpawnPoint.position, SpawnPoint.rotation));
        } else {
            Debug.LogError("BossPrefab or SpawnPoint is not assigned in the Inspector!");
        }
    }

    /// <summary>
    /// Instantiates a single, randomly selected enemy at the spawn point.
    /// </summary>
    void SpawnEnemy() {
        if (EnemyCharacterPrefabs.Count == 0) {
            Debug.LogError("EnemyCharacterPrefabs list is empty!");
            return;
        }
        if (SpawnPoint == null) {
            Debug.LogError("SpawnPoint is not assigned!");
            return;
        }

        // 1. Pick a random enemy prefab
        int randomIndex = Random.Range(0, EnemyCharacterPrefabs.Count);
        GameObject enemyPrefab = EnemyCharacterPrefabs[randomIndex];

        // 2. Instantiate it at the spawn point
        GameObject spawned = Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        spawned.AddComponent<AICharacterControl>();
        _enemiesSpawned.Add(spawned);
    }
}