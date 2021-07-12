using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowCharacters : MonoBehaviour
{
    static public GameObject Sent;
    public GameObject[] Characters;

    public void HT()
    {
        Sent = Characters[0];
        SceneManager.LoadScene("Characters");
    }

    public void S()
    {
        Sent = Characters[1];
        SceneManager.LoadScene("Characters");
    }

    public void PGL()
    {
        Sent = Characters[2];
        SceneManager.LoadScene("Characters");
    }

    public void PHL()
    {
        Sent = Characters[3];
        SceneManager.LoadScene("Characters");
    }

    public void DA()
    {
        Sent = Characters[4];
        SceneManager.LoadScene("Characters");
    }

    public void PA()
    {
        Sent = Characters[5];
        SceneManager.LoadScene("Characters");
    }
}
