using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject startButton = null;

    public void DisableStartButton()
    {
        startButton.SetActive(false);
    }

}
