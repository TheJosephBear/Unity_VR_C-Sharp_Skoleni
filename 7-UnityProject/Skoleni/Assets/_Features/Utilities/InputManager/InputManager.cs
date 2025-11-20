using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

    public event Action<Vector2> OnMoveInput;
    public event Action OnAttackInput;
    public event Action OnPauseInput;

    private void Update() {
        // Move
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveInput?.Invoke(move);

        // Attack
        if (Input.GetKeyDown(KeyCode.Space))
            OnAttackInput?.Invoke();

        // Pause
        if (Input.GetKeyDown(KeyCode.P))
            OnPauseInput?.Invoke();
    }

}
