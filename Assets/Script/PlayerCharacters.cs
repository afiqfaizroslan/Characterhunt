using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacters : MonoBehaviour
{
    private Animator anim;
    public GameObject[] Player;
    public string[] name;
    int show;


    private GameObject Clone;

    void Start()
    {

        string PlayerCharacter = PlayerPrefs.GetString("PlayerCharacter", "male");
        if (PlayerCharacter.Equals("male"))
        {
            Clone = (GameObject)Instantiate(Player[0], this.transform);
            show = 0;
        }
        else
        {
            Clone = (GameObject)Instantiate(Player[1], this.transform);
            show = 1;
        }


    }

    public void Other()
    {
        Destroy(Clone);

        if (show == 0)
        {
           
            Clone = (GameObject)Instantiate(Player[1], this.transform);
            show = 1;
        }
        else 
        {
            Clone = (GameObject)Instantiate(Player[0], this.transform);
            show = 0;
        }
    }

    public void save()
    {
        if (show == 0) 
        { 
            PlayerPrefs.SetString("PlayerCharacter", "male");
            SceneManager.LoadScene("Mainmenu");
        }

        if (show == 1) 
        { 
            PlayerPrefs.SetString("PlayerCharacter", "female");
            SceneManager.LoadScene("Mainmenu");
        }
    }
}
