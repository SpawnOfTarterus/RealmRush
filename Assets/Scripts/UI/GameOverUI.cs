using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Text gameOverText = null;

    private void Start()
    {
        UpdateGameOverText();
    }

    private void UpdateGameOverText()
    {
        if(FindObjectOfType<ScoreControl>().GetScore() == 2600 && FindObjectOfType<LivesControl>().GetCurrentLives() == 10)
        {
            gameOverText.text = $"Wow! Perfect Score! {Environment.NewLine} Score: {FindObjectOfType<ScoreControl>().GetScore()} with {FindObjectOfType<LivesControl>().GetCurrentLives()} Lives left!";
        }
        else if(FindObjectOfType<ScoreControl>().GetScore() < 2600 && FindObjectOfType<LivesControl>().GetCurrentLives() > 0)
        {
            gameOverText.text = $"Congratulations! {Environment.NewLine} Score: {FindObjectOfType<ScoreControl>().GetScore()} with {FindObjectOfType<LivesControl>().GetCurrentLives()} Lives left.";
        }
        else
        {
            gameOverText.text = $"You ran out of lives! {Environment.NewLine} Score: {FindObjectOfType<ScoreControl>().GetScore()} ";
        }
    }
}
