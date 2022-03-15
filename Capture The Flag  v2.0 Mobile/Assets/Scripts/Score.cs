using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameVariables;

public class Score : MonoBehaviour
{
    public Text redScoreText;
    public Text blueScoreText;

    void Update()
    {
        redScoreText.text = "RED TEAM : " + redScore;
        blueScoreText.text = "BLUE TEAM : " + blueScore;
    }
}
