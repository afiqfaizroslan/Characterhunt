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

        anim = Clone.transform.GetChild(0).GetComponent<Animator>();

    }

    public GameObject getClone()
    {
        return Clone;
    }

    public void Dance()
    {
        anim.Play("Dance");
    }

    public void Flip()
    {
        anim.Play("BackFlip");
    }
    public void Kick()
    {
        anim.Play("Kick");
    }
    public void Greeting()
    {
        anim.Play("Greeting");
    }

}
