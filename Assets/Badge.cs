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
        Content.text = "Badge unlocked by collecting character from warrior category (Hang tuah)";
    }

    public void Royal()
    {
        Panel.SetActive(true);
        Icon.GetComponent<Image>().sprite = sprite[1];
        Title.text = "ROYAL";
        Content.text = "Badge unlocked by collecting all character from ROYAL category (Sultan, Puteri Hang li poh)";
    }

    public void Legend()
    {
        Panel.SetActive(true);
        Icon.GetComponent<Image>().sprite = sprite[2];
        Title.text = "LEGENDARY";
        Content.text = "Badge unlocked  by collecting all character from lagend and myth category (Hang Tuah, Puteri Gunung Ledang)";
    }

    public void Sovereign()
    {
        Panel.SetActive(true);
        Icon.GetComponent<Image>().sprite = sprite[3];
        Title.text = "SOVEREIGN";
        Content.text = "Badge unlocked by collecting all character from Colonizer category  (Dutch Army, Portugis Army)";
    }

    public void close()
    {
        Panel.SetActive(false);
    }

}
