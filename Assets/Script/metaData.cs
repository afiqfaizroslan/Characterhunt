using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaData : MonoBehaviour
{
    string ID;

    [Geocode]
    public string _locationStrings;
    Vector2d locations;


    public void greeting()
    {

    }

    public string getID()
    {
        return ID;
    }
}
