using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayGameState : GameStateBase {

    public GameObject vCamRefference;

    public override void Enter() {
        Time.timeScale = 1f;
        vCamRefference.SetActive(true);
        FindAnyObjectByType<GameplayManager>().StartGame();
    }

    public override void Exit() {
        FindAnyObjectByType<GameplayManager>().ExitGame();
    }
}
