using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallBallZone : MonoBehaviour
{

    public BasketBallManager BbManagerReff;


    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Basket BALL")) {
            BbManagerReff.ResetBall();
        }
    }
}
