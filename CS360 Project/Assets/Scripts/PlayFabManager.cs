using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

// This code is not yet complete
public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;
    public Button registerBtn;
    public Button loginBtn;


    void Start()
    {
        // Assign the RegisterButton method to the button's onClick event
        if (registerBtn != null)
        {
            registerBtn.onClick.AddListener(RegisterButton);
        }

        if (loginBtn != null)
        {
            loginBtn.onClick.AddListener(LoginButton);
        }
    }
    public void RegisterButton() {

        if (passwordInput.text.Length < 6) {
            messageText.text = "Password too short!";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text, 
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false 
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
        Debug.Log("PlayFab User ID: " + result.PlayFabId);
    }

    void OnRegisterError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }



    public void LoginButton() {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text, 
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginError);
    
    }

    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in!";
        Debug.Log("Successful login/create account!");
    }

    void OnLoginError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        //Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }


    // 
    void OnError(PlayFabError error)
    {
        //messageText.text = error.ErrorMessage;
        Debug.Log("Error while getting leaderboard");
        Debug.Log(error.GenerateErrorReport());
    }

    public GameObject rowPrefab;
    public Transform rowsParent;

    // For leaderboard scores to send to PlayFab
    public void SendLeaderboard(int score) {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "GainedPoints",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    // If the score is updated it updates the leaderboard
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent!");       

        // Check if the "B" key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Load your target scene
            SceneManager.LoadScene("StartScene");
        }
    }
 

    // Gets the leaderboard
    public void GetLeaderboard() {
        var request = new GetLeaderboardRequest {
            StatisticName = "RampageHighScores",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    // Shows the leaderboard
    // Gets all the information like position, player name and score for each entry
    void OnLeaderboardGet(GetLeaderboardResult result)
    {

        // Remove all existing rows
        foreach (Transform item in rowsParent) {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard) {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();

            // Get position on leaderboard, then player id then player score
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(string.Format("PLACE: {0} | ID: {1} | VALUE: {2} ", 
            item.Position + " " + item.PlayFabId + " " + item.StatValue));
        }
    }


    
}

