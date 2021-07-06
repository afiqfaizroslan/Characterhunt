
using Mapbox.Unity.Map;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instantobj : MonoBehaviour
{
    private Animator anim;
    public GameObject item;

    [Geocode]
    Vector2d userLoc;
    Vector2d itemlocation;


    private GameObject Clone;

    void Start()
    {

        //Clone = (GameObject)Instantiate(LocationStatus.item, this.transform);
       Clone = (GameObject)Instantiate(item, this.transform);
        anim = Clone.GetComponent<Animator>();
        
    }

    public GameObject getClone()
    {
        return Clone;
    }

}
