using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsUIHandler : MonoBehaviour
{
    [SerializeField] Text descriptionText = null;

    public void UpdateDescriptionText(string newText)
    {
        descriptionText.text = newText;
        descriptionText.gameObject.SetActive(true);
    }

    public void TurnOffDescriptiveText()
    {
        descriptionText.gameObject.SetActive(false);
    }

}
