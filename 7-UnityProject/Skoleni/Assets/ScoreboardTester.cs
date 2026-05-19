using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardTester : MonoBehaviour
{

    public Scoreboard ScoreboardInSceneRefference;

    public void ScoreIncrease() {
        ScoreboardInSceneRefference.IncreaseScore();
    }

}
