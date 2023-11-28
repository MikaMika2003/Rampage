using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStart : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
         // Check if the "F" key is pressed
         //play again
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Load your target scene
            SceneManager.LoadScene("PlayingScene");
        }

         // Check if the "F" key is pressed
         //play again
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Load your target scene
            SceneManager.LoadScene("LoginRegister");
        }
    }
}
