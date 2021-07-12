using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUI : MonoBehaviour
{
    public Text Name;
    public Text BgStory;
    public Text Points;
    public GameObject TheCharacter;
    // Start is called before the first frame update
    void Start()
    {
        string name = TheCharacter.transform.GetChild(0).GetComponent<META>().Name;
        int points = TheCharacter.transform.GetChild(0).GetComponent<META>().Point;
        string bgStory = TheCharacter.transform.GetChild(0).GetComponent<META>().BgStory;

        Name.text = name;
        BgStory.text = bgStory;
        Points.text = ""+points;
    }

}
