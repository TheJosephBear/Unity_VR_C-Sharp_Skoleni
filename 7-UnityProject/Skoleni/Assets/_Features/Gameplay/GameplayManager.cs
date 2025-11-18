using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    /// <summary>
    /// Manages the runtime of the game - initializing, running 
    /// and exiting the gameplay part of the game
    /// </summary>

    public GameObject PlayerCharacterPrefab;
    public Vector3 PlayerSpawnPoint;
    public EnemySpawner EnemySpawnerRefference;
    GameObject _playerInstance;

    public void StartGame() {
        SpawnPlayerCharacter();
        EnableEnemySpawning();
    }

    public void StopGame() {
        EnemySpawnerRefference.DeleteAllEnemies();
        Destroy(_playerInstance);
    }

    void SpawnPlayerCharacter() {
        _playerInstance = Instantiate(PlayerCharacterPrefab, PlayerSpawnPoint, Quaternion.identity);
        _playerInstance.AddComponent<InputCharacterControl>();
        _playerInstance.AddComponent<Player>();
        _playerInstance.tag = "Player";
    }

    void EnableEnemySpawning() {
        EnemySpawnerRefference.StartWaveSpawn();
    }
}

public enum CharacterClass {
    Melee,
    Ranged,
    Speedster
}
