using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    InputManager _inputManagerPrefab;
    [HideInInspector, NonSerialized]
    public InputManager Input = null;

    public List<GameStateBase> gameStateClassList = new List<GameStateBase>();


    public event Action<GameState> OnGameStateChanged;
    public event Action<InputManager> OnInputReady;
    public event Action<IDamageable, int> OnAnyHit;

    GameState _currentGameState;
    GameStateBase _currentGameStateClass;

    void Start() {
        Initialize();
    }

    void Initialize() {
        // Input init
        Input = Instantiate(_inputManagerPrefab);
        OnInputReady?.Invoke(Input);

        // Initial state
        ChangeGameState(GameState.MainMenu);
    }

    public void ChangeGameState(GameState newState) {
        if(_currentGameStateClass != null) {
            // exit if trying to change to already selected state
            if (newState == _currentGameStateClass.gameState)
                return;

            // Exit previous state
            _currentGameStateClass.Exit();
        }
        
        _currentGameStateClass = gameStateClassList.Find(baseClass => baseClass.gameState == newState);
        _currentGameState = newState;
        _currentGameStateClass.Enter();
        OnGameStateChanged?.Invoke(newState); // Fire event
    }

    public void RaiseOnHitEvent(IDamageable hit, int damage) {
        OnAnyHit?.Invoke(hit, damage);
    }

}

public enum GameState {
    MainMenu,
    Running,
    PauseMenu,
    GameOver,
}