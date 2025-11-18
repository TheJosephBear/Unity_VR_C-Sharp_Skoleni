using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacter : Character {

    protected override void Die() {
        GameManager.Instance.ChangeGameState(GameState.GameOver);
        base.Die();
    }

}
