using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantobjc : MonoBehaviour
{
    private Animator anim;

    private GameObject Clone;

    void Start()
    {

        Clone = (GameObject)Instantiate(ShowCharacters.Sent, this.transform);

        anim = Clone.GetComponent<Animator>();

    }

    public GameObject getClone()
    {
        return Clone;
    }
}
