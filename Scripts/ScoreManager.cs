using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float killPoints = 10;

    public TextMeshProUGUI scoreText;

    public static ScoreManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        // Updates the score text and saves the score to PlayerPrefs
        scoreText.text = PlayerPrefs.GetFloat("totalScore").ToString() + "%";
        PlayerPrefs.SetFloat("totalScore", score);
    }
}
