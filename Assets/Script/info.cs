using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public GameObject infoPanel;
    private bool opened;
    private GameObject[] audio;

    void Start()
    {
        opened = false;
        audio = GameObject.FindGameObjectsWithTag("BtnSound");
    }

    public void onClick()
    {
        if (opened)
        {
            audio[1].GetComponent<AudioSource>().Play(0);
            infoPanel.SetActive(false);
            opened = false;
        }
        else
        {
            audio[0].GetComponent<AudioSource>().Play(0);
            infoPanel.SetActive(true);
            opened = true;
        }
    }
}
