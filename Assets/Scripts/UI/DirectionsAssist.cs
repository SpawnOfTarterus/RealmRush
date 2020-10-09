using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsAssist : MonoBehaviour
{
    DirectionsUIHandler directionsUIHandler;

    private void Start()
    {
        directionsUIHandler = FindObjectOfType<DirectionsUIHandler>();
    }

    private void OnMouseEnter()
    {
        if (GetComponent<Tower>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Tower. Towers can be placed on BuildLocations only. Towers will continually shoot at Enemies in range. Only a fixed number of towers can be built in each level.");
        }
        else if (GetComponent<Wall>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Tower. Towers can be placed on BuildLocations only. Towers will continually shoot at Enemies in range. Only a fixed number of towers can be built in each level.");
        }
        else if (GetComponent<BuildLocation>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Tower. Towers can be placed on BuildLocations only. Towers will continually shoot at Enemies in range. Only a fixed number of towers can be built in each level.");
        }
        else if (GetComponent<Enemy>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Tower. Towers can be placed on BuildLocations only. Towers will continually shoot at Enemies in range. Only a fixed number of towers can be built in each level.");
        }
        else if (GetComponent<Block>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Tower. Towers can be placed on BuildLocations only. Towers will continually shoot at Enemies in range. Only a fixed number of towers can be built in each level.");
        }
    }

    private void OnMouseExit()
    {
        directionsUIHandler.TurnOffDescriptiveText();
    }

}
