using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour {

    public TextMeshProUGUI TextReff1;
    public TextMeshProUGUI TextReff2;
    public TextMeshProUGUI TextReff3;
    public TextMeshProUGUI TextReff4;

    int _currentScore = 0;

    private void Awake() {
        UpdateUIs();
    }

    public void IncreaseScore() {
        _currentScore++;
        UpdateUIs();
    }

    void UpdateUIs() {
        TextReff1.text = _currentScore.ToString();
        TextReff2.text = _currentScore.ToString();
        TextReff3.text = _currentScore.ToString();
        TextReff4.text = _currentScore.ToString();
    }

}
