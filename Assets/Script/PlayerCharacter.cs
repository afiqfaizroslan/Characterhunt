using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Animator anim;
    public GameObject[] Player;



    private GameObject Clone;

    void Start()
    {

        string PlayerCharacter = PlayerPrefs.GetString("PlayerCharacter","male");
        if (PlayerCharacter.Equals("male")) 
        { 
            Clone = (GameObject)Instantiate(Player[0], this.transform); 
        }
        else 
        { 
            Clone = (GameObject)Instantiate(Player[1], this.transform); 
        }

        anim = Clone.GetComponent<Animator>();

    }

    public GameObject getClone()
    {
        return Clone;
    }
}
