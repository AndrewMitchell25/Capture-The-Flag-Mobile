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
    [SerializeField] GameObject ad;
    private GameObject thisAd;

	public void Quit()
	{
		Application.Quit();
	}

	public void StartOver()
	{
        int nextScene;
        if (twoPlayers == true)
        {
            nextScene = 2;
            redScore = 0;
            blueScore = 0;
        }
        else
        {
            nextScene = 3;
            redScore = 0;
            blueScore = 0;
        }

        thisAd = Instantiate(ad, new Vector3(0, 0, 0), Quaternion.identity);
        thisAd.GetComponent<InterstitialAd>().SetNextScene(nextScene);
        thisAd.GetComponent<InterstitialAd>().LoadAd();
        thisAd.GetComponent<InterstitialAd>().ShowAd();
    }

    public void Menu()
    {
        thisAd = Instantiate(ad, new Vector3(0, 0, 0), Quaternion.identity);
        thisAd.GetComponent<InterstitialAd>().SetNextScene(0);
        thisAd.GetComponent<InterstitialAd>().LoadAd();
        thisAd.GetComponent<InterstitialAd>().ShowAd();
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
