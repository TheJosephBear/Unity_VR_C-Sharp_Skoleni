using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateBase : MonoBehaviour {
    public GameState gameState;
    public abstract void Enter();
    public abstract void Exit();
}
