using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMap : MonoBehaviour
{
    public GameObject[] maps;
    public GameObject template;

    void Start()
    {
        ChooseMap();
    }

    private void Update()
    {
        if (Input.GetKey("space") && Input.GetKeyDown("z"))
        {
            ChooseMap();
        }

    }

    public void ChooseMap()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }

        template.SetActive(false);
        int randMap = Random.Range(0, maps.Length);
        Debug.Log(randMap);
        maps[randMap].SetActive(true);
    }

}
