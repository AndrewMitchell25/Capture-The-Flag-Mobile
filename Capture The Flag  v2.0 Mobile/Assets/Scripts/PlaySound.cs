using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void SoundPlay()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }
}
