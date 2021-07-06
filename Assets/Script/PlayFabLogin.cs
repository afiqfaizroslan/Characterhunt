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
    public InputField emailInput;
    public InputField passwordInput;
    public Toggle Remember;
    public GameObject loading;

    void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1)
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = PlayerPrefs.GetString("Email"),
                Password = PlayerPrefs.GetString("Password"),
            };

            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginsuccess, OnError);

        }
        else { loading.SetActive(false); }
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginsuccess, OnError);
    
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

    void OnLoginsuccess(LoginResult result)
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void PaswordResetButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "F788A"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
         messageText.text = "Password Reset link sent! Check your Email.";
    }

    void OnError(PlayFabError error)
      {
            messageText.text = error.ErrorMessage;
            Debug.Log(error.GenerateErrorReport());
      }

}
