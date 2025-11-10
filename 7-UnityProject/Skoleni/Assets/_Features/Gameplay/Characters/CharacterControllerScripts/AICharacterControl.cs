using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AICharacterControl : MonoBehaviour {

    Character characterComponent;

    void Start() {
        characterComponent = GetComponent<Character>();
    }

    void Update() {
        HandleMove();
    }

    void HandleMove() {
        characterComponent.SetMoveInput(new Vector2(1,1));
    }

}
