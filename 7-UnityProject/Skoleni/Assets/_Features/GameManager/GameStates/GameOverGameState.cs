using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverGameState : GameStateBase {

    public GameObject GameoverUIPrefab;
    GameObject _GameoverUIInstance;

    public override void Enter() {
        Time.timeScale = 0f;
        _GameoverUIInstance = Instantiate(GameoverUIPrefab);
    }

    public override void Exit() {
        Destroy(_GameoverUIInstance);
    }
}
