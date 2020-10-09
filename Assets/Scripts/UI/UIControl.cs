using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject startButton = null;
    [SerializeField] Text levelDisplayText = null;
    [SerializeField] Text errorText = null;
    float errorTextDisplayTime = 2f;

    public void DisableStartButton()
    {
        startButton.SetActive(false);
    }

    private void Start()
    {
        levelDisplayText.text = $"Level {SceneManager.GetActiveScene().buildIndex - 2}";
    }

    public void DisplayErrorText(string errorMessage)
    {
        errorText.text = errorMessage;
        errorText.gameObject.SetActive(true);
        StartCoroutine(TurnOffErrorText());
    }

    IEnumerator TurnOffErrorText()
    {
        yield return new WaitForSeconds(errorTextDisplayTime);
        errorText.gameObject.SetActive(false);
    }
}
