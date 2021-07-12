using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DAO : MonoBehaviour
{

    private string Errormsg;bool success = false;
    private string email; private string psw;
    private string name;

    [Header("Register")]
    public Text messageRegister;
    public InputField RuNameInput;
    public InputField RemailInput;
    public InputField RpasswordInput;

    [Header("player name")]
    public bool OnName;
    public InputField nameInput;
    public GameObject namePanel;
    private bool gotName; private string pName;

    [Header("AR")]
    public GameObject UnlockedPanel;
    public GameObject TheCharacter;
    public Text Message;

    [Header("Achivement")]
    public bool OnAchivement;
    public Button[] badges = new Button[4];
    public Button[] Characters = new Button[6];
    public Text point;
    public Text Playername;
    public Text level;
    public Text pointTonext;
    public Color DisabledColor;
    public Color NormalColor;

    void Start()
    {
        if (OnName)
        {
            OnAchivement = false;
            GetName();
            if (!gotName)
            {
                
            }
            else
            {
                namePanel.SetActive(false);
            }
        }

        if (OnAchivement)
        {
            OnName = false;
            Getdata();

            
        }
    }

    void OnErrorR(PlayFabError error)
    {
        messageRegister.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Succesfull");
        Login(RemailInput.text, RpasswordInput.text);
    }

    public void Register()
    {
        if (RuNameInput.text == "" || RemailInput.text == "" || RpasswordInput.text == "")
        {
            messageRegister.text = "Fill all field";
            return;
        }
        else
        {
            if (RpasswordInput.text.Length < 6)
            {
                messageRegister.text = "Password too Short";
                return;
            }
            else
            {
                var request = new RegisterPlayFabUserRequest
                {
                    Username = RuNameInput.text,
                    Email = RemailInput.text,
                    Password = RpasswordInput.text,
                };
                PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnErrorR);
            }

        }
       
       
    }

    public void Login(string Email, string Password)
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

    void OnLoginsuccess(LoginResult result)
    {
        success = true;
        SceneManager.LoadScene("Mainmenu");
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("name successfully saved");
        namePanel.SetActive(false);
    }

    void OnDataReceived(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("PlayerName"))
        {
            Debug.Log("name is " + result.Data["PlayerName"].Value);
            pName = result.Data["PlayerName"].Value;
            if (string.IsNullOrEmpty(pName))
            {
                namePanel.SetActive(true);
            }
            else
            {
                namePanel.SetActive(false);
            }

        }
        else
        {
            Debug.Log("name is null");
            namePanel.SetActive(true);
        }
    }

    void OnError(PlayFabError error)
    {
        Errormsg = error.ErrorMessage;
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

    //get name for mainmenu
     public void GetName()
     {
         PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
     }

     public void setName()
     {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
             {
                 {"PlayerName", nameInput.text},
                 {"Points","100"},
                 {"Badges",""},
                 {"HT",""},
                 {"S",""},
                 {"PGL",""},
                 {"PHL",""},
                 {"DA",""},
                 {"PA",""}

             }
         };
         PlayFabClientAPI.UpdateUserData(request,OnDataSend,OnError);
     }

    // function for achivement page
    public void Getdata()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnAllDataReceived, OnError);
    }
    void OnAllDataReceived(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("PlayerName") && result.Data.ContainsKey("Points"))
        {
            Debug.Log("Data gathered"+ result.Data["PlayerName"].Value + result.Data["Points"].Value);
            Playername.text = result.Data["PlayerName"].Value;
            point.text = result.Data["Points"].Value;
            level.text = GetLevel(int.Parse(result.Data["Points"].Value));
            pointTonext.text = result.Data["Points"].Value + "/" + PointToNext(GetLevel(int.Parse(result.Data["Points"].Value)));

            bool HT = false; bool S = false; bool PGL = false; bool PHL = false; bool DA = false; bool PA = false;

            if (string.IsNullOrEmpty(result.Data["HT"].Value))
                { Characters[0].interactable = false; }
            else { Characters[0].interactable = true; HT = true; }

            if (string.IsNullOrEmpty(result.Data["S"].Value))
                { Characters[1].interactable = false; }
            else { Characters[1].interactable = true; S = true; }

            if (string.IsNullOrEmpty(result.Data["PGL"].Value))
                { Characters[2].interactable = false; }
            else { Characters[2].interactable = true; PGL = true; }

            if (string.IsNullOrEmpty(result.Data["PHL"].Value))
                { Characters[3].interactable = false; }
            else { Characters[3].interactable = true; PHL = true; }

            if (string.IsNullOrEmpty(result.Data["DA"].Value))
                { Characters[4].interactable = false; }
            else { Characters[4].interactable = true; DA = true; }

            if (string.IsNullOrEmpty(result.Data["PA"].Value))
                { Characters[5].interactable = false; }
            else { Characters[5].interactable = true; PA = true; }


            if (HT)        { ColorBlock cb = badges[0].colors; cb.normalColor = NormalColor; badges[0].colors = cb; } else { ColorBlock cb = badges[0].colors; cb.normalColor = DisabledColor; badges[0].colors = cb; }
            if (S && PHL)  { ColorBlock cb = badges[1].colors; cb.normalColor = NormalColor; badges[1].colors = cb; } else { ColorBlock cb = badges[1].colors; cb.normalColor = DisabledColor; badges[1].colors = cb; }
            if (HT && PGL) { ColorBlock cb = badges[2].colors; cb.normalColor = NormalColor; badges[2].colors = cb; } else { ColorBlock cb = badges[2].colors; cb.normalColor = DisabledColor; badges[2].colors = cb; }
            if (DA && PA)  { ColorBlock cb = badges[3].colors; cb.normalColor = NormalColor; badges[3].colors = cb; } else { ColorBlock cb = badges[3].colors; cb.normalColor = DisabledColor; badges[3].colors = cb; }


        }
        else
        {
            Debug.Log("Data not complete");
        }
    }

    public string GetLevel(int Points)
    {
        string level;
        if (Points < 300)
        {
            level = "Newcomer";
        }
        else if (Points < 500)
            {
                level = "Traveller";
            }
               else if (Points < 900)
                    {
                        level = "Tourist";
                    }
                    else
                    {
                        level = "Explorer";
                    }
        return level;
    }

    public int PointToNext(string level)
    {
        int point = 0;
        if (level.Equals("Newcomer"))
        {
            point = 300;
        }
        if (level.Equals("Traveller"))
        {
            point = 500;
        }
        if (level.Equals("Tourist"))
        {
            point = 900;
        }
        return point;
    }

    //function for AR page

    public void AR()
    {
        GetPoints();

    }

    void OnIDSend(UpdateUserDataResult result)
    {
        Debug.Log(" successfully saved");
        UnlockedPanel.SetActive(false);
    }

    public void GetPoints()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnPointsReceived, OnError);
    }
    void OnPointsReceived(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("PlayerName") && result.Data.ContainsKey("Points"))
        {
            Debug.Log("Data gathered" + result.Data["PlayerName"].Value + result.Data["Points"].Value);
            string ID = TheCharacter.transform.GetChild(0).GetComponent<META>().ID;
            int allPoint = int.Parse(result.Data["Points"].Value) + TheCharacter.transform.GetChild(0).GetComponent<META>().Point ;
            if (string.IsNullOrEmpty(result.Data[ID].Value))
            {
                var request = new UpdateUserDataRequest
                {
                    Data = new Dictionary<string, string>
                    {
                     {ID, "true"},
                     {"Points", allPoint+""}

                    }
                };
                PlayFabClientAPI.UpdateUserData(request, OnIDSend, OnError);
            }
            else 
            {
                UnlockedPanel.SetActive(false) ;
               
            }

        }
        else
        {
            Debug.Log("Data not complete");
        }
    }





}
