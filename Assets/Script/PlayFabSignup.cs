using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabSignup : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField UnameInput;
    public InputField emailInput;
    public InputField passwordInput;

    public void RegisterButton()
    {
        if (UnameInput.text == "" || emailInput.text == "" || passwordInput.text == "")
        {
            messageText.text = "Fill all field";
            return;
        }
        else
        {
            if (passwordInput.text.Length < 6)
            {
                messageText.text = "Password too Short";
                return;
            }

            var request = new RegisterPlayFabUserRequest
            {
                Username = UnameInput.text,
                Email = emailInput.text,
                Password = passwordInput.text,
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        }
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Succesfully register proceed to login page ";
        DoDelayAction(3);
    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
        SceneManager.LoadScene("Login");
    }
}
