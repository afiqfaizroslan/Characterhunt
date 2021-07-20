using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    bool showed = false;
    GameObject[] audio;

    void Start()
    { audio = GameObject.FindGameObjectsWithTag("BtnSound"); }
    public void show()
    {
       

        if (showed == false)
        {
            audio[0].GetComponent<AudioSource>().Play(0);
            Debug.Log("Pressed");
            transform.Translate(+600,0, 0);
            showed = true;
        }
        else
        {
            audio[1].GetComponent<AudioSource>().Play(0);
            Debug.Log("Pressed showed");
            transform.Translate(-600, 0, 0);
            showed = false;
        }

    }
}
