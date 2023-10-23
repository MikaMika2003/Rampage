using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;

    public void RegisterButton() {

    }

    public void LoginButton() {
        
    }

    public void ResetPasswordButton() {
        
    }


    //void OnPasswordReset(SendAccountRecoveryEmailResult result)






    void Start()
    {
        Login();
    }

    void Login() {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }


}
