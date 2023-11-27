using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OpenGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Load your target scene
            SceneManager.LoadScene("PlayingScene");
        }

        // Check if the "L" key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Load your target scene
            SceneManager.LoadScene("Leaderboard");
        }
    }
}
