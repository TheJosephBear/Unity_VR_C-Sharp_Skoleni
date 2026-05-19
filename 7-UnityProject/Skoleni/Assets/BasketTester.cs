using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTester : MonoBehaviour
{
   public BasketBallManager basketBallManager;

    private void Start() {
        basketBallManager.SpawnNewBall();
    }
}
