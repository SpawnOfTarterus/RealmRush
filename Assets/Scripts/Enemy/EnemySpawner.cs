using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] Enemy enemyPrefab = null;
    [SerializeField] Block startBlock = null;
    [SerializeField] int maxEnemies = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int enemiesSpawned = 0; enemiesSpawned < maxEnemies; enemiesSpawned++)
        {
            Enemy enemyInstance = Instantiate(enemyPrefab, startBlock.transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
