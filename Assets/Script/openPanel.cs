using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPanel : MonoBehaviour
{
    public GameObject HowtoPanel;
    public GameObject AboutPanel;
  

    public void OpenHowTo()
    {
        HowtoPanel.SetActive(true);
   
    }

    public void OpenAbout()
    {
        AboutPanel.SetActive(true);
    
    }

    public void CloseHowTo()
    {
        HowtoPanel.SetActive(false);
    }

    public void CloseAbout()
    {
        AboutPanel.SetActive(false);
    }
}
