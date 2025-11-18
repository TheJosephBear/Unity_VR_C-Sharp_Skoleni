using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayGameState : GameStateBase {

    public GameObject vcamReff;
    GameplayManager _gameplayManager;

    private void Awake() {
        _gameplayManager = FindAnyObjectByType<GameplayManager>();
        vcamReff.SetActive(false);
    }

    public override void Enter() {
        vcamReff.SetActive(true);
        Time.timeScale = 1.0f;
        _gameplayManager.StartGame();
    }

    public override void Exit() {
        vcamReff.SetActive(false);
        _gameplayManager.StopGame();
    }
}
