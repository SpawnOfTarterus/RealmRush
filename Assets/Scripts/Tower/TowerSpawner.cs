using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] Tower towerPrefab = null;
    Queue<Tower> towerQueue = new Queue<Tower>();
    public bool gameStarted = false;
    [SerializeField] Transform towerResetLocation = null;
    [SerializeField] int towerLimit = 8;

    public void RemoveAllTowers()
    {
        var allTowers = FindObjectsOfType<Tower>();
        foreach(Tower tower in allTowers)
        {
            tower.transform.position = towerResetLocation.position;
            if (tower.builtPosition != null) { tower.builtPosition.SetLocationStatus(false); }
            tower.builtPosition = null;
        }
    }

    public void PreCheckTowerPlacement(BuildLocation buildLocation)
    {
        if(gameStarted) { Debug.Log("Can not build once the round has started."); return; }
        if(buildLocation.GetLocationStatus()) { Debug.Log("Tower already placed here."); return; }
        CheckToMoveOrBuild(buildLocation);
    }

    private void CheckToMoveOrBuild(BuildLocation buildLocation)
    {
        Debug.Log(towerQueue.Count);
        if (towerQueue.Count < towerLimit)
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
        if (movedTower.builtPosition != null) { movedTower.builtPosition.SetLocationStatus(false); }
        movedTower.transform.position = spawnPos.transform.position;
        spawnPos.SetLocationStatus(true);
        movedTower.builtPosition = spawnPos;
    }
}
