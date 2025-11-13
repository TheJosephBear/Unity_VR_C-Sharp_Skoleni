using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverGameState : GameStateBase
{

    public override void Enter() {
        Time.timeScale = 0f;
    }

    public override void Exit() {

    }
}
