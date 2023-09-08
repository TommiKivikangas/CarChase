using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Start()
    {
        // sets the score text to the total score
        scoreText.text = PlayerPrefs.GetFloat("totalScore").ToString() + "%";
    }
}
