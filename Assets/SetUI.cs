using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetUI : MonoBehaviour
{
    public Text Name;
    public Text BgStory;
    public Text Points;
    public GameObject TheCharacter;
    private GameObject[] Canvas;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectsWithTag("Canvas");

        string name = TheCharacter.transform.GetChild(0).GetComponent<META>().Name;
        int points = TheCharacter.transform.GetChild(0).GetComponent<META>().Point;
        string bgStory = TheCharacter.transform.GetChild(0).GetComponent<META>().BgStory;

        Name.text = name;
        BgStory.text = bgStory;
        Points.text = ""+points;
        for (int i=0;i< Canvas.Length;i++)
        {
            Canvas[i].SetActive(false);
        }
        
    }

    public void Back()
    {
        for (int i=0;i< Canvas.Length;i++)
        {
            Canvas[i].SetActive(true);
        }
        SceneManager.UnloadSceneAsync("Characters");
    }

}
