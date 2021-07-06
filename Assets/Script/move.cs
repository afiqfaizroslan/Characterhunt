using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    bool showed = false;

    public void show()
    {
        if (showed == false)
        {
            Debug.Log("Pressed");
            transform.Translate(+600,0, 0);
            showed = true;
        }
        else
        {
            Debug.Log("Pressed showed");
            transform.Translate(-600, 0, 0);
            showed = false;
        }

    }
}
