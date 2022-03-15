using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameVariables;



public class Credits : MonoBehaviour
{
    public Text winnerText;
    public Sprite redBG;
    public Sprite blueBG;

	public void Quit()
	{
		Application.Quit();
	}

	public void StartOver()
	{
        if (twoPlayers == true)
        {
            SceneManager.LoadScene(2);
            redScore = 0;
            blueScore = 0;
        }
        else
        {
            SceneManager.LoadScene(3);
            redScore = 0;
            blueScore = 0;
        }

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        if (lastScorerRed == true)
        {
            GetComponent<Image>().sprite = redBG;
            winnerText.text = "RED WINS!";
        }
        else
        {
            GetComponent<Image>().sprite = blueBG;
            winnerText.text = "BLUE WINS!";
        }
        
    }
}
