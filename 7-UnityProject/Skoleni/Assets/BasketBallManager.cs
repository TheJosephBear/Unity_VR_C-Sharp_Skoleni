using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallManager : MonoBehaviour {

    public Scoreboard ScoreboardReff;
    public Transform BallSpawnPosition;
    public GameObject BallPrefab;

    public bool SpawnBallOnStart;

    GameObject _spawnedBall;

    private void Awake() {
        if(SpawnBallOnStart) SpawnNewBall();
    }


    public void SpawnNewBall() {
        _spawnedBall = Instantiate(BallPrefab, BallSpawnPosition.position, Quaternion.identity);
    }

    public void ResetBall() {
        _spawnedBall.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        _spawnedBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        _spawnedBall.transform.position = BallSpawnPosition.position;
    }

    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Basket BALL")) {
            ScoreboardReff.IncreaseScore();
            ResetBall();
            // TODO: Pøidat efekt wauuu
        }
    }

}
