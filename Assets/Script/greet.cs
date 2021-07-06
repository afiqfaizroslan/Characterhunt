using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greet : MonoBehaviour
{
    private Animator anim;
    public GameObject HT;
    private GameObject HTnew;

    public void greeting()
    {
        anim.Play("Salute");
    }

    public void Flip()
    {
        anim.Play("Backflip");
    }

    public void get()
    {
        HTnew = (GameObject)Instantiate(HT, new Vector3(0, 0, 0), Quaternion.identity);
        anim = HTnew.GetComponent<Animator>();
    }
}
