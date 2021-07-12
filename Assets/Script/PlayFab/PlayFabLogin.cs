using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabLogin : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public Text PanelText;
    public InputField emailInput;
    public InputField passwordInput;
    public InputField RecoveryInput;
    public Toggle Remember;
    public GameObject loading;
    public GameObject Recovery;
    DAO dao = new DAO();

    void Start()
    {
       
        if (PlayerPrefs.GetInt("Saved") == 1)
        {
            string Email = PlayerPrefs.GetString("Email");
            string Password = PlayerPrefs.GetString("Password");
            dao.Login(Email,Password);
            if (!dao.GetSuccess())
            {
                loading.SetActive(false);
            }
        }
        else 
        { 
            loading.SetActive(false); 
        }
    }

    public void LoginButton() 
    { 
        dao.Login(emailInput.text,passwordInput.text);
        messageText.text = dao.GetError();
        if (Remember.isOn == true)
        {
            PlayerPrefs.SetString("Email", emailInput.text);
            PlayerPrefs.SetString("Password", passwordInput.text);
            PlayerPrefs.SetInt("Saved", 1);
            PlayerPrefs.Save();
            Debug.Log("Saved ");
            Debug.Log(PlayerPrefs.GetString("Email"));
        }


    }

    public void openRecovery()
    {
        Recovery.SetActive(true);
    }
    public void CloseRecovery()
    {
        Recovery.SetActive(false);
    }

    public void PaswordResetButton()
    {
        if (RecoveryInput.text == "")
        {
            RecoveryInput.text = "enter your email";
        }
        else 
        {
            dao.PaswordReset(RecoveryInput.text);
            Recovery.SetActive(false);

            messageText.text = "Recovery email sent";
        }
        
    }

 

   
   

}
