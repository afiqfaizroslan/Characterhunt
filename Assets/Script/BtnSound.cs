using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSound : MonoBehaviour
{
    private GameObject[] audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectsWithTag("BtnSound");
    }

    public void Open()
    {
        audio[0].GetComponent<AudioSource>().Play(0);
    }

    public void Close()
    {
        audio[1].GetComponent<AudioSource>().Play(0);
    }
}
