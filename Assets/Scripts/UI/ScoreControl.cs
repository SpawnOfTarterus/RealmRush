using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    int currentScore = 0;
    Text scoreText;

    void Start()
    {
        currentScore = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = currentScore.ToString("Score: 0000");
    }

    public void AddToScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString("Score: 0000");
    }

    public int GetScore()
    {
        return currentScore;
    }
}
