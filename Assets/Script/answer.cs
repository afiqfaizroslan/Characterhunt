using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answer : MonoBehaviour
{
    public GameObject AR;
    public GameObject Unlocked;
    public GameObject Answer;
    private Animator anim;
    public Text Name;
    public Text Content;
    public float timeremain;
    public float Overtime;
    public Button[] Q;
    

    void Start()
    {
        Unlocked.SetActive(false);
        Answer.SetActive(false);

        Q[0].interactable = false;
        Q[1].interactable = false;
        Q[2].interactable = false;
        Q[3].interactable = false;

    }
    void Update()
    {

        Name.text = AR.transform.GetChild(0).GetComponent<META>().getName() + " :";
        Unlocked.transform.GetChild(0).GetComponent<Image>().sprite = AR.transform.GetChild(0).GetComponent<META>().getFace();
        if (timeremain > 0)
        {
            timeremain -= Time.deltaTime;
        }
        else
        {
            Answer.SetActive(false);
        }


    }
    public void greeting()
    {
        anim = AR.transform.GetChild(0).GetComponent<Animator>();
        anim.Play(AR.transform.GetChild(0).GetComponent<META>().GetAnimation(1));
        Content.text = "Hi...";
        Answer.SetActive(true);
        timeremain = 5;
        DoDelayAction(timeremain, 0,false);

    }

    public void A1()
    {
        Content.text = AR.transform.GetChild(0).GetComponent<META>().GetAnswer(0);
        Answer.SetActive(true);
        anim.Play(AR.transform.GetChild(0).GetComponent<META>().GetAnimation(2));
        timeremain = AR.transform.GetChild(0).GetComponent<META>().GetCD(0);
        DoDelayAction(timeremain, 1,false);
    }

    public void A2()
    {
        Content.text = AR.transform.GetChild(0).GetComponent<META>().GetAnswer(1);
        Answer.SetActive(true);
        anim.Play(AR.transform.GetChild(0).GetComponent<META>().GetAnimation(3));
        timeremain = AR.transform.GetChild(0).GetComponent<META>().GetCD(1);
        DoDelayAction(timeremain, 2,false);
    }

    public void A3()
    {
        Content.text = AR.transform.GetChild(0).GetComponent<META>().GetAnswer(2);
        Answer.SetActive(true);
        anim.Play(AR.transform.GetChild(0).GetComponent<META>().GetAnimation(2));
        timeremain = AR.transform.GetChild(0).GetComponent<META>().GetCD(2);
        DoDelayAction(timeremain, 3,false);
    }

    public void A4()
    {
        Content.text = AR.transform.GetChild(0).GetComponent<META>().GetAnswer(3);
        Answer.SetActive(true);
        anim.Play(AR.transform.GetChild(0).GetComponent<META>().GetAnimation(4));
        timeremain = AR.transform.GetChild(0).GetComponent<META>().GetCD(3);
        DoDelayAction(timeremain, 3, true);
    }

    void DoDelayAction(float delayTime,int index, bool last)
    {
        StartCoroutine(DelayAction(delayTime,index,last));
    }

    IEnumerator DelayAction(float delayTime, int index, bool last)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        if (!last)
        {
            //Do the action after the delay time has finished.
            Q[index].interactable = true;
        }
        else
        {
            Answer.SetActive(false);
            if (!AR.transform.GetChild(0).GetComponent<META>().isUnlocked())
            {
                Unlocked.SetActive(true);
                AR.transform.GetChild(0).GetComponent<META>().Unlocked();
                StartCoroutine(Unlockview(2));
            }
        }
    }

    IEnumerator Unlockview(float delayTime)
    {
        //Wait for the specified delay time before continuing.

        yield return new WaitForSeconds(delayTime);
        Unlocked.SetActive(false);



    }
}
