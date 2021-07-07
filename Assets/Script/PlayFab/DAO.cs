using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DAO : MonoBehaviour
{
    private string Errormsg;
    bool success = false ;
    private string email; private string psw; private string name;

    public void Register(string uname,string Email,string Password)
    {
        email = Email;psw = Password; name = uname;
        var request = new RegisterPlayFabUserRequest
        {
            Username = uname,
            Email = Email,
            Password = Password, 
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
       
    }

    public void Login( string Email,string Password)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = Email,
            Password = Password,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginsuccess, OnError);
    }

    public void PaswordReset(string Email)
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = Email,
            TitleId = "F788A"
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
         Errormsg = "Password Reset link sent! Check your Email.";
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Succesfull");
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Succesfull");
        Login(email,psw);
    }


    void OnLoginsuccess(LoginResult result)
        {
            success = true;
            SceneManager.LoadScene("Mainmenu");
        }

    void OnError(PlayFabError error)
    {
        Errormsg  = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    public string GetError()
    {
        return Errormsg;
    }

    public bool GetSuccess()
    {
        return success;
    }

}
