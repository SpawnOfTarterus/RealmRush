using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] Tower towerPrefab = null;
    public Queue<Tower> towerQueue = new Queue<Tower>();
    public bool gameStarted = false;
    [SerializeField] Transform towerResetLocation = null;
    [SerializeField] int towerLimit = 8;
    [SerializeField] Text towerCountText = null;
    int currentTowersInPlay = 0;

    public void UpdateTowerCountText()
    {
        if(towerCountText == null) { return; }
        towerCountText.text = $"Towers {currentTowersInPlay}/{towerLimit}";
    }

    private void Start()
    {
        UpdateTowerCountText();
    }

    public void RemoveAllTowers()
    {
        var allTowers = FindObjectsOfType<Tower>();
        foreach(Tower tower in allTowers)
        {
            tower.transform.position = towerResetLocation.position;
            if (tower.builtPosition != null) { tower.builtPosition.SetLocationStatus(false); }
            tower.builtPosition = null;
        }
        currentTowersInPlay = 0;
        UpdateTowerCountText();
    }

    public void PreCheckTowerPlacement(BuildLocation buildLocation)
    {
        if(gameStarted) { FindObjectOfType<UIControl>().DisplayErrorText("Can not build once the round has started."); return; }
        if(buildLocation.GetLocationStatus()) { FindObjectOfType<UIControl>().DisplayErrorText("Tower already placed here."); return; }
        CheckToMoveOrBuild(buildLocation);
    }

    private void CheckToMoveOrBuild(BuildLocation buildLocation)
    {
        if (towerQueue.Count < towerLimit)
        {
            BuildTower(buildLocation);
            currentTowersInPlay++;
            UpdateTowerCountText();
        }
        else
        {
            MoveTower(buildLocation);
            if(currentTowersInPlay < towerLimit) { currentTowersInPlay++; }
            UpdateTowerCountText();
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
