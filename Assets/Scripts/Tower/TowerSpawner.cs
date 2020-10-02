using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] Tower towerPrefab = null;
    Queue<Tower> towerQueue = new Queue<Tower>();

    public void PreCheckTowerPlacement(BuildLocation buildLocation)
    {
        if(buildLocation.GetLocationStatus()) { Debug.Log("Tower already placed here."); return; }
        CheckToMoveOrBuild(buildLocation);
    }

    private void CheckToMoveOrBuild(BuildLocation buildLocation)
    {
        Debug.Log(towerQueue.Count);
        if (towerQueue.Count < 3)
        {
            BuildTower(buildLocation);
        }
        else
        {
            MoveTower(buildLocation);
        }
    }
    
    public void BuildTower(BuildLocation spawnPos)
    {
        Tower towerInstance = Instantiate(towerPrefab, spawnPos.transform.position, Quaternion.identity, transform);
        towerQueue.Enqueue(towerInstance);
        towerInstance.builtPosition = spawnPos;
        spawnPos.GetComponent<BuildLocation>().SetLocationStatus(true);
    }

    private void MoveTower(BuildLocation spawnPos)
    {
        Tower movedTower = towerQueue.Dequeue();
        towerQueue.Enqueue(movedTower);
        movedTower.builtPosition.SetLocationStatus(false);
        movedTower.transform.position = spawnPos.transform.position;
        spawnPos.GetComponent<BuildLocation>().SetLocationStatus(true);
        movedTower.builtPosition = spawnPos;
    }
}
