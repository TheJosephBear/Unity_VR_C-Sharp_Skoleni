using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverGameState : GameStateBase {

    public GameObject UIRefference;

    public override void Enter() {
        Time.timeScale = 0f;
        UIRefference.SetActive(true);
    }

    public override void Exit() {
        UIRefference.SetActive(false);
    }
}
