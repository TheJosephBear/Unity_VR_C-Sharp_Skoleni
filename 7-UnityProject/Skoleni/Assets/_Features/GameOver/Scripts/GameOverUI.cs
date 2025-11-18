using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour {
    public void OnContinue() {
        GameManager.Instance.ChangeGameState(GameState.MainMenu);
    }
}
