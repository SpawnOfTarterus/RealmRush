using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{

    public void GetSelection(GameObject selection)
    {
        if (selection.GetComponent<BuildLocation>())
        {
            BuildLocation buildlocation = selection.GetComponent<BuildLocation>();
            FindObjectOfType<TowerSpawner>().PreCheckTowerPlacement(buildlocation);
        }
        else
        {
            Debug.Log("Can't build here! This is a " + selection);
        }
    }
}
