using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
   public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        arrow.transform.rotation = Quaternion.Euler( 0, 0, +Input.compass.trueHeading);
    }
}
