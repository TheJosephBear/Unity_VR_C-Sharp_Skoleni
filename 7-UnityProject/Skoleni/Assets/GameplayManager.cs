using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public GameObject PlayerCharacterRefference;
    public EnemySpawner EnemySpawnerReff;
    public Vector3 PlayerSpawnPoint;

    GameObject _player;

    public void StartGame() {
        // Vytvoøit hráèe
        CreatePlayer();
        // Enemy spawner aktivovat
        EnemySpawnerReff.StartWaveSpawn();
    }

    public void ExitGame() {
        // Smazat všechny jednotky vèetnì hráèe
        if(_player != null) Destroy(_player);
        EnemySpawnerReff.DeleteAllEnemies();
    }

    void CreatePlayer() {
        _player = Instantiate(PlayerCharacterRefference, PlayerSpawnPoint, Quaternion.identity);
        _player.AddComponent<InputCharacterControl>();
        _player.AddComponent<PlayerScript>();
        _player.tag = "Player";
    }

}
