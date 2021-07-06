using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compass : MonoBehaviour
{
    public GameObject Map; 

    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
    }

    public void compassbtn()
    {
        Map.transform.rotation = Quaternion.Euler(0, +Input.compass.trueHeading, 0);
    }
}
