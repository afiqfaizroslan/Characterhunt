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
    DAO dao = new DAO();

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
            else 
            {
                dao.Register(UnameInput.text, emailInput.text, passwordInput.text);
            }

        }
 
    }
}
