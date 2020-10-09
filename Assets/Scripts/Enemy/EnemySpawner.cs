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
    public List<Enemy> enemiesInPlay = new List<Enemy>();

    public void StartSpawningEnemies()
    {
        if(FindObjectOfType<PathFinder>().PathFind() == null) { FindObjectOfType<UIControl>().DisplayErrorText("Cannot start level if path is blocked."); return; }
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
            enemiesInPlay.Add(enemyInstance);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveEnemyFromInPlayList(Enemy enemy)
    {
        enemiesInPlay.Remove(enemy);
        int currentLives = FindObjectOfType<LivesControl>().GetCurrentLives();
        if(enemiesInPlay.Count == 0 && currentLives != 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextSceneWithDelay();
        }
    }
}
