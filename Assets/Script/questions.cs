﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class questions : MonoBehaviour
{
    public GameObject AR;
    public Text[] Qtext;
    private bool pressed;

    void Start()
    {
        pressed = false;
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        Qtext[0].text = AR.transform.GetChild(0).GetComponent<META>().GetQuestion(0);
        Qtext[1].text = AR.transform.GetChild(0).GetComponent<META>().GetQuestion(1);
        Qtext[2].text = AR.transform.GetChild(0).GetComponent<META>().GetQuestion(2);
        Qtext[3].text = AR.transform.GetChild(0).GetComponent<META>().GetQuestion(3);
    }

    public void iButton()
    {
        if (!pressed)
        {
            this.gameObject.SetActive(true);
            pressed = true;
        }
        else
        {
            this.gameObject.SetActive(false);
            pressed = false;
        }
    }
}
