using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next : MonoBehaviour

{
    public GameObject Popup;
    public static int previous;

    void update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
         SceneManager.LoadScene("Mainmenu");
        }
    }
    public void ok()
    {
        Popup.SetActive(false);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void map()
    {
        if (!Input.location.isEnabledByUser)
        {
            Popup.SetActive(true);
        }
        else
        {
            SceneManager.LoadSceneAsync("map"); 
        }
        
    }
    public void Character()
    {
        SceneManager.LoadScene("Character");
    }
    public void AR()
    {
        SceneManager.LoadScene("AR");
    }
    public void Achievement()
    {
        previous = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Achievement", LoadSceneMode.Additive);
        Debug.Log("Active Scene index:" + previous);
    }
    public void Setting()
    {
        previous = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Setting", LoadSceneMode.Additive);
        Debug.Log("Active Scene index:" + previous);
    }
    public void About()
    {
        SceneManager.LoadScene("About");
    }
    public void sigup()
    {
        SceneManager.LoadScene("Signup");
    }
    public void Login()
    {
        SceneManager.LoadScene("Login");
    }
}
