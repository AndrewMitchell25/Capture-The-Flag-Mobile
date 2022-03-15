using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenuFlags : MonoBehaviour
{
    //adjust this to change speed
    public float speed = 3f;
    //adjust this to change how high it goes
    public float height = 0.2f;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code

        //calculate what the new Y position will be
        float newY = -Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z);
    }

}
