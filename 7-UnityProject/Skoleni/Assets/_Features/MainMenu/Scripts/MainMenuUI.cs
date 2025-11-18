using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {
    
    public void OnStart() {
        GameManager.Instance.ChangeGameState(GameState.Running);
    }

    public void OnExit() {
        Application.Quit();
    }

}
