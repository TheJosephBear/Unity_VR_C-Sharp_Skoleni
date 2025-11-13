using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : Character {

    bool diedOnce = false;

    public override void TakeDamage(int damageAmount) {
        GameManager.Instance.RaiseOnHitEvent(this, damageAmount);

        _currentHealth -= damageAmount;
        print($"I took damage! {_currentHealth} / {MaxHealth}");
        if (_currentHealth <= 0) {
            if (!diedOnce) {
                _currentHealth = MaxHealth;
                diedOnce = true;
            } else {
                Die();
            }
        }
    }

    protected override void Die() {
        GameManager.Instance.ChangeGameState(GameState.GameOver);
        base.Die();
    }
}
