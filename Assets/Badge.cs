using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Badge : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Icon;
    public Text Title;
    public Text Content;
    public Sprite[] sprite;

    public void Warrior()
    {
        Panel.SetActive(true);
        Icon.GetComponent<Image>().sprite = sprite[0];
        Title.text = "WARRIOR";
        Content.text = "You have unlocked this by collecting all character from warrior category";
    }

    public void Royal()
    {
        Panel.SetActive(true);
        Icon.GetComponent<Image>().sprite = sprite[1];
        Title.text = "ROYAL";
        Content.text = "You have unlocked this by collecting all character from ROYAL category";
    }

    public void Legend()
    {
        Panel.SetActive(true);
        Icon.GetComponent<Image>().sprite = sprite[2];
        Title.text = "LEGENDARY";
        Content.text = "You have unlocked this by collecting all character from lagend and myth category";
    }

    public void Sovereign()
    {
        Panel.SetActive(true);
        Icon.GetComponent<Image>().sprite = sprite[3];
        Title.text = "SOVEREIGN";
        Content.text = "You have unlocked this by collecting all character from Colonixer category";
    }

    public void close()
    {
        Panel.SetActive(false);
    }

}
