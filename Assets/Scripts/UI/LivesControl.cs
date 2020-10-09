using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesControl : MonoBehaviour
{
    int currentLives = 0;
    int maxLives = 10;
    Text livesText;

    public int GetCurrentLives()
    {
        return currentLives;
    }

    void Start()
    {
        currentLives = maxLives;
        livesText = GetComponent<Text>();
        livesText.text = currentLives.ToString("Lives: 00");
    }

    public void LoseLife()
    {
        if(currentLives == 0 ) { return; }
        currentLives--;
        livesText.text = currentLives.ToString("Lives: 00");
        if (currentLives == 0)
        {
            FindObjectOfType<SceneLoader>().LoadGameOverWithDelay();
        }
    }
}
