using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameVariables;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject options;

    public void SetPlayers2()
    {
        twoPlayers = true;
        SceneManager.LoadScene(1);
        redScore = 0;
        blueScore = 0;

    }

    public void SetPlayers4()
    {
        twoPlayers = false;
        SceneManager.LoadScene(1);
        redScore = 0;
        blueScore = 0;
    }

    public void OpenOptions()
    {
        options.SetActive(true);
    }
}
