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
            FindObjectOfType<UIControl>().DisplayErrorText("Can't build here! This is a " + selection.name.Substring(0, selection.name.Length - (selection.name.Length - 4)));
        }
    }
}
