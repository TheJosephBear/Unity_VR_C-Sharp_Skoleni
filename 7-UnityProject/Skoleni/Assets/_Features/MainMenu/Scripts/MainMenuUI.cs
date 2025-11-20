using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {
    
    public void OnStart() {
        GameManager.Instance.ChangeGameState(GameState.Running);
    }

    public void OnJumper() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkakackaScene");
    }

    public void OnExit() {
        Application.Quit();
    }

}
