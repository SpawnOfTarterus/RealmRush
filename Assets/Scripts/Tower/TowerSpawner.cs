using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] Tower towerPrefab = null;

    public void buildTower(BuildLocation spawnPos)
    {
        if(!spawnPos.GetLocationStatus())
        {
            Tower towerInstance = Instantiate(towerPrefab, spawnPos.transform.position, Quaternion.identity, transform);
            spawnPos.GetComponent<BuildLocation>().SetLocationStatus(true);
        }
        else
        {
            Debug.Log("Tower already placed here.");
        }
    }
}
