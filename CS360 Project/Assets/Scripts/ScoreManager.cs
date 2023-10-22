using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;

    int score = 0;

    // Call the database to get the highscore and set it to highscore
    // int highscore = 0;


    // This will be called at the very start of the game before Start() is called
    // Will set an instance of the Manager that can be used in other classes
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }


    public void AddPoint()
    {
        //score += 1 //or however many points should be added
        scoreText.text = score.ToString();

        // To save the highscore
        //if (hignscore < score) 
        //    PlayerPrefs.SetInt("hignscore", score);
      
    }
}
