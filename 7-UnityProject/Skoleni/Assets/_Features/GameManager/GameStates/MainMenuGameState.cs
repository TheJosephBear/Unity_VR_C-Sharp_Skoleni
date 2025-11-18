using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameState : GameStateBase {

    public GameObject MainMenuUIPrefab;
    public GameObject vcamReff;
    GameObject _mainMenuUIInstance;


    private void Awake() {
        vcamReff.SetActive(false);
    }

    public override void Enter() {
        vcamReff.SetActive(true);
        _mainMenuUIInstance = Instantiate(MainMenuUIPrefab);
    }

    public override void Exit() {
        vcamReff.SetActive(false);
        Destroy(_mainMenuUIInstance);
    }
}
