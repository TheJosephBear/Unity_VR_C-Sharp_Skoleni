using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Character characterScript;

    private void Start() {
        characterScript = GetComponent<Character>();

        characterScript.OnDeath += OnCharacterDeath;
    }

    void OnCharacterDeath() {
        GameManager.Instance.ChangeGameState(GameState.GameOver);
    }
}
