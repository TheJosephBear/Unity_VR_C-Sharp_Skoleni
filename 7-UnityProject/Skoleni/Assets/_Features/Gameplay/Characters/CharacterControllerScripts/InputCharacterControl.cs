using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Character))]
public class InputCharacterControl : MonoBehaviour {

    Character characterComponent;


    void Start() {
        characterComponent = GetComponent<Character>();
    }

    void HandleMoveInput(Vector2 moveInput) {
        characterComponent.SetMoveInput(moveInput);
    }

    void HandleAttackInput() {
        characterComponent.PerformAttack();
    }

    void OnEnable() {
        if(GameManager.Instance == null) {
            InputManager.Instance.OnMoveInput += HandleMoveInput;
            InputManager.Instance.OnAttackInput += HandleAttackInput;
            return;
        }
        GameManager.Instance.Input.OnMoveInput += HandleMoveInput;
        GameManager.Instance.Input.OnAttackInput += HandleAttackInput;
        GameManager.Instance.OnInputReady += SubscribeToInput;
    }

    void SubscribeToInput(InputManager input) {
        input.OnMoveInput += HandleMoveInput;
        input.OnAttackInput += HandleAttackInput;
    }

    void OnDisable() {
        GameManager.Instance.Input.OnMoveInput -= HandleMoveInput;
        GameManager.Instance.Input.OnAttackInput -= HandleAttackInput;
    }


}
