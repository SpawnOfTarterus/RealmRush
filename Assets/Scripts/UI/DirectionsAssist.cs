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
            directionsUIHandler.UpdateDescriptionText("This is a Tower. Towers can be placed on Build Locations only. Towers will continually shoot at Enemies in range. Only a fixed number of towers can be built in each level.");
        }
        else if (GetComponent<Wall>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Wall. Walls can not be traveled across by Enemies nor can Towers be built on them.");
        }
        else if (GetComponent<BuildLocation>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Build Location. Build Locations can be traveled by Enemies. Towers can be placed here to redirect the Enemies path.");
        }
        else if (GetComponent<Enemy>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Enemy. Enemies spawn at their base and will travel across Build Locations and Paths on their way to the Player Base. If an Enemy reaches the Player Base, the Player will lose a life.");
        }
        else if (GetComponent<Block>())
        {
            directionsUIHandler.UpdateDescriptionText("This is a Path. Paths can be traveled by Enemies, but unlike Build Locations; Paths can not be built on.");
        }
        else if (GetComponent<EnemySpawner>())
        {
            directionsUIHandler.UpdateDescriptionText("This is the Enemy Base. Enemies spawn here before traveling towards the Player Base.");
        }
        else if (GetComponent<PathFinder>())
        {
            directionsUIHandler.UpdateDescriptionText("This is the Pathing Area. Enemies will always take the shortest path to the Player Base. Towers can be placed on Build Locations to redirect Enemies.");
        }
        else if (GetComponent<TowerSpawner>())
        {
            directionsUIHandler.UpdateDescriptionText("This is the Player Base. Once an Enemy reaches the Player Base, it will expload and the Player will lose a life.");
        }

    }

    private void OnMouseExit()
    {
        directionsUIHandler.TurnOffDescriptiveText();
    }

}
