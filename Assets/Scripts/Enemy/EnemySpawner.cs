using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] Enemy enemyPrefab = null;
    [SerializeField] Block startBlock = null;
    [SerializeField] int maxEnemies = 1;
    [SerializeField] Transform FXParent = null;

    public void StartSpawningEnemies()
    {
        if(FindObjectOfType<PathFinder>().PathFind() == null) { Debug.Log("Cannot start level if path is blocked."); return; }
        FindObjectOfType<UIControl>().DisableStartButton();
        FindObjectOfType<TowerSpawner>().gameStarted = true;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int enemiesSpawned = 0; enemiesSpawned < maxEnemies; enemiesSpawned++)
        {
            Enemy enemyInstance = Instantiate(enemyPrefab, startBlock.transform.position, Quaternion.identity, transform);
            enemyInstance.FXParent = FXParent;
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
