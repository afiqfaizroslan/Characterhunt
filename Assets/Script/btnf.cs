using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Examples;

public class btnf : MonoBehaviour
{
    public Transform target;
    public bool follow;
    public GameObject camera;
    public Button button;
    public GameObject Map;

    public Color DisabledColor;
    public Color NormalColor;
    float x = Float(1.41); float y = Float(42.56); float z = Float(-17.72);

    private GameObject[] audio;
    public GameObject PanZoom;

    void Start()
    {
       
        Input.location.Start();
        Input.compass.enabled = true;

        audio = GameObject.FindGameObjectsWithTag("BtnSound");

    }
    void Update()
    {
        if (follow == true)
        {
            ColorBlock cb = button.colors;
            cb.normalColor = NormalColor;
            button.colors = cb;
            
            
            Map.transform.position = new Vector3(target.position.x, target.position.y, target.position.z );
            
            Map.GetComponent<RotateWithLocationProvider>().enabled = true;


        }
        else 
        {
            ColorBlock cb = button.colors;
            cb.normalColor = DisabledColor;
            button.colors = cb;
            Map.GetComponent<RotateWithLocationProvider>().enabled = false;
        }

    }

    public void btnfollow()
    {
        if(follow == false)
        {
            follow = true;
            camera.transform.position = new Vector3(x, y, z);
            PanZoom.SetActive(false);
            audio[0].GetComponent<AudioSource>().Play(0);
        }
        else
        { 
            follow = false;
            PanZoom.SetActive(true);
            Map.transform.rotation = Quaternion.Euler(0, 0, 0);
            audio[1].GetComponent<AudioSource>().Play(0);

        }
    }

    public void compassbtn()
    {
        Map.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private static float Float(double value)
    {
        return (float)value;
    }
}
