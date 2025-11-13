using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Character characterScript;

    private void Awake() {
        characterScript = GetComponent<Character>();

        characterScript.OnCharacterDeath += OnDeath;
    }

    void OnDeath() {
        GameManager.Instance.ChangeGameState(GameState.GameOver);
    }


}
