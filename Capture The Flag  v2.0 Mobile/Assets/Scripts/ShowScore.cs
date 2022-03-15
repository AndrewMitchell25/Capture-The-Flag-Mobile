using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameVariables;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text red;
    public Text blue;


    private void Start()
    {
        red.text = redScore.ToString();
        blue.text = blueScore.ToString();
    }

    public void NextLevel()
    {
        if (redScore < gameNum && blueScore < gameNum)
        {
            if (twoPlayers == true)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
        else
        {
            SceneManager.LoadScene(5);
        }
       
        
    }

}
