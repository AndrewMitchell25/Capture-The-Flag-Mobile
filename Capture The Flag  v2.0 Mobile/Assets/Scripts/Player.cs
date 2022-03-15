using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameVariables;

public class Player : MonoBehaviour
{
    private float speed = playerSpeed;
    public bool isTagged;
    public bool captured;
    public bool pickedUp;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public GameObject jail;
    public Animator camAnim;
    public float waitTime2 = 2f;
    public float waitTime4 = 8;
    public bool movement = true;
    public GameObject effect;
    public Vector3 outOfJail;
    public CircleCollider2D collider1;
    public Animator score;
    public int playerNum;
    public int team;
    public int enemy;
    public bool inJail;
    public Joystick joystick;
    public GameObject teammate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        //Pause for a second while the camera zooms in
        StartCoroutine(PauseControls(1));
    }

    void Update()
    {
        //Take input from joysticks and create a moveVelocity variable
        Vector2 moveInput = new Vector2(0,0);
        if (joystick.Horizontal >= .2f)
        {
            moveInput.x = 1;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            moveInput.x = -1;
        }
        if (joystick.Vertical >= .2f)
        {
            moveInput.y = 1;
        }
        else if (joystick.Vertical <= -.2f)
        {
            moveInput.y = -1;
        }
        moveVelocity = moveInput.normalized * speed;


        //If the flag has been captured, spawns the effect and starts the transition to next scene
        //For both teams
        if (team == 1 && transform.position.x <= -0.5f && pickedUp == true && captured == false)
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            StartCoroutine(CapturedPause(.3f, true));
        }
        if (team == 2 && transform.position.x >= 0.5f && pickedUp == true && captured == false)
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            StartCoroutine(CapturedPause(.3f, false));
        }

        //Makes sure both players can't think they have the flag at the same time
        if (teammate.GetComponent<Player>().pickedUp == true)
        {
            pickedUp = false;
        }
    }

    void FixedUpdate()
    {
        //If the player has been tagged
        if (isTagged == true)
        {
            //Play the tagged sound, move the player to jail, spawn the effect and screen shake
            FindObjectOfType<AudioManager>().Play("Tagged");
            transform.position = jail.transform.position;
            Instantiate(effect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("Shake");
            inJail = true;
            isTagged = false;
            pickedUp = false;

            //Go to jail and wait there for time depending on how many players
            if (twoPlayers == false)
            {
                StartCoroutine(GetOutOfJail(waitTime4));
            }
            else
            {
                StartCoroutine(GetOutOfJail(waitTime2));
            }
        }
        else
        {
            //Actually move the player
            if (movement == true)
            {
                rb.MovePosition(rb.position + moveVelocity * Time.deltaTime); //switch to FixedDeltaTime
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Pick up opponents flag 
        if (other.name == "Flag " + enemy)
        {
            pickedUp = true;
         }

        //Get tagged by enemy
        if (other.CompareTag("Team" + enemy))
        {
            if (team == 1)
            {
                isTagged |= (transform.position.x > 0 && movement == true);
            }

            if(team == 2)
            {
                isTagged |= (transform.position.x < 0 && movement == true);
            }
        }

        //Tags your teammate out of jail
        if (other.CompareTag("Team" + team) && inJail == true)
        {
            if (other.GetComponent<Player>().inJail == false)
            {
                if (movement == false && pause == false)
                {
                    FindObjectOfType<AudioManager>().Play("TaggedOutOfJail");
                    pickedUp = false;
                    transform.position = outOfJail;
                    Instantiate(effect, transform.position, Quaternion.identity);
                    collider1.enabled = true;
                    movement = true;
                    inJail = false;
                }
            }
            else //If you are in jail too, then both players wait a shorter amount of time
            {
                StartCoroutine(GetOutOfJail(waitTime2));
            }
        }
    }

    //Just wait - used for the pause button
    IEnumerator PauseControls(float time)
    {
        movement = false;
        yield return new WaitForSeconds(time);
        
        movement = true;
    }

    //Wait in jail
    IEnumerator GetOutOfJail(float time)
    {
        movement = false;
        collider1.enabled = false;
        pickedUp = false;
        yield return new WaitForSeconds(time);
        if (movement == false)
        {
            FindObjectOfType<AudioManager>().Play("OutOfJail");
            transform.position = outOfJail;
            Instantiate(effect, transform.position, Quaternion.identity);
            movement = true;
            inJail = false;
            collider1.enabled = true;
        }
    }

    //Wait for split second before winning the round and switching scenes to spawn the effect
    IEnumerator CapturedPause(float time, bool red)
    {
        captured = true;
        movement = false;
        yield return new WaitForSeconds(time);

        if (red == true)
        {
            redScore += 1;
            lastScorerRed = true;
        }
        else
        {
            blueScore += 1;
            lastScorerRed = false;
        }

        Captured();
    }

}

