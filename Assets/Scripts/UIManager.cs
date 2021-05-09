using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text maxScoreText;
    private int maxScore;
    public int points;

    private void Start()
    {
        Advertisement.Initialize("4122238");
        
        maxScore = PlayerPrefs.GetInt("maxScore", 0);

        maxScoreText.text = "Max Score: " + maxScore.ToString();
    }

    public void AddPoint()
    {
        points += 1;
        pointText.text = points.ToString();

        if (maxScore < points)
        {
            PlayerPrefs.SetInt("maxScore", points);
            maxScoreText.text = "Max Score: " + points.ToString();
        }
    }

    public void ShowAds()
    {
        Advertisement.Show();
        // Restart level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    
    }
}
