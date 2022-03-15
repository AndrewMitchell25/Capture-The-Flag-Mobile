using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameVariables;


public class Flag : MonoBehaviour
{
    
    
    private Player player2Script;
    public GameObject player2;
    public GameObject player4;
    private Player player4Script;
    public GameObject effect;
    public Vector3 offset;
    public Vector3 pickedUpSize;
    private Vector3 startingPos;
    private Vector3 startingScale;
    private bool touchedNow;

    
    void Start()
    {
        
        startingPos = transform.position;
        startingScale = transform.localScale;
        player2Script = player2.GetComponent<Player>();
        if (twoPlayers == false)
        {
            player4Script = player4.GetComponent<Player>();
        }

    }

    
    void Update()
    {
        if (player2Script.pickedUp == true)
        {
            if (touchedNow == false)
            {
                touchedNow = true;
                Instantiate(effect, transform.position, Quaternion.identity);

                FindObjectOfType<AudioManager>().Play("GrabFlag");
            }
            transform.position = player2.transform.position + offset;
            transform.localScale = pickedUpSize;

            if (player2Script.isTagged == true)
            {
                touchedNow = false;
                transform.position = startingPos;
                transform.localScale = startingScale;
                Instantiate(effect, transform.position, Quaternion.identity);
            }

        }

        if (twoPlayers == false && player4Script.pickedUp == true)
        {
            if (touchedNow == false)
            {
                touchedNow = true;
                Instantiate(effect, transform.position, Quaternion.identity);

                FindObjectOfType<AudioManager>().Play("GrabFlag");
            }
            transform.position = player4.transform.position + offset;
            transform.localScale = pickedUpSize;

            if (player4Script.isTagged == true)
            {
                touchedNow = false;
                transform.position = startingPos;
                transform.localScale = startingScale;
                Instantiate(effect, transform.position, Quaternion.identity);
            }

        }

        //Tries to fix a glitch of the flag not going back by making it always go back unless it is
        //picked up
        if (twoPlayers == true)
        {
            if (player2Script.pickedUp == false)
            {
                touchedNow = false;
                transform.position = startingPos;
                transform.localScale = startingScale;
            }
        }
        else
        {
            if (player2Script.pickedUp == false && player4Script == false)
            {
                touchedNow = false;
                transform.position = startingPos;
                transform.localScale = startingScale;
            }
        }

  
    }

    
}
