using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEMO : MonoBehaviour
{
    public Toggle demo;
    void Start()
    {
        string D = PlayerPrefs.GetString("Demo", "Off");
        if (D.Equals("On"))
        {
            demo.isOn = true;
        }
        else
        {
            demo.isOn = false;
        }
    }

    public void Demo()
    {
        if (demo.isOn)
        {
            PlayerPrefs.SetString("Demo", "On");
        }
        else
        {
            PlayerPrefs.SetString("Demo", "Off");
        }
    }
}
