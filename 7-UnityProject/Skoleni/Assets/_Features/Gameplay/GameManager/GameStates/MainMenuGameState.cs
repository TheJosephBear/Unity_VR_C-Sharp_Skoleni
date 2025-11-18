using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameState : GameStateBase {

    public GameObject MainMenuUIRefference;
    public GameObject vCamRefference;

    public override void Enter() {
        Time.timeScale = 0f;
        // Aktivoval UI
        MainMenuUIRefference.SetActive(true);
        // Aktivoval kameru
        vCamRefference.SetActive(true);
    }

    public override void Exit() {
        MainMenuUIRefference.SetActive(false);
        vCamRefference.SetActive(false);

    }
}
