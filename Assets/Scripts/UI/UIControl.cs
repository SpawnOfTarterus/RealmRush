using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject startButton = null;
    [SerializeField] GameObject removeTowersButton = null;
    [SerializeField] GameObject changeViewButton = null;
    [SerializeField] Text levelDisplayText = null;
    [SerializeField] Text errorText = null;
    [SerializeField] GameObject errorTextBox = null;
    [SerializeField] Camera mainCamera = null;
    [SerializeField] Camera buildViewCamera = null;
    [SerializeField] Text changeViewText = null;
    float errorTextDisplayTime = 2f;

    public void SwitchView()
    {
        if(mainCamera.isActiveAndEnabled)
        {
            mainCamera.gameObject.SetActive(false);
            buildViewCamera.gameObject.SetActive(true);
            changeViewText.text = "Main View";
        }
        else if(buildViewCamera.isActiveAndEnabled)
        {
            buildViewCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            changeViewText.text = "Build View";
        }
    }

    public void DisableButtons()
    {
        if (buildViewCamera.isActiveAndEnabled)
        {
            buildViewCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }
        changeViewButton.SetActive(false);
        startButton.SetActive(false);
        removeTowersButton.SetActive(false);
    }

    private void Start()
    {
        changeViewText.text = "Build View";
        levelDisplayText.text = $"Level {SceneManager.GetActiveScene().buildIndex - 2}";
    }

    public void DisplayErrorText(string errorMessage)
    {
        errorText.text = errorMessage;
        errorTextBox.SetActive(true);
        StartCoroutine(TurnOffErrorText());
    }

    IEnumerator TurnOffErrorText()
    {
        yield return new WaitForSeconds(errorTextDisplayTime);
        errorTextBox.SetActive(false);
    }
}
