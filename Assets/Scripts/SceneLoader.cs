using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies = new List<Enemy>();

    float levelTransitionTime = 3f;

    public void LoadLevel1()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadNextSceneWithDelay()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {

        yield return new WaitForSeconds(levelTransitionTime);
        LoadNextScene();
    }

    public void LoadMainMenu()
    {
        FindObjectOfType<DoNotDestroyOnLoad>().ResetScoreAndLives();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadGameOverWithDelay()
    {
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        var towers = FindObjectOfType<TowerSpawner>().towerQueue;
        foreach (Tower tower in towers)
        {
            tower.levelLost = true;
        }
        enemies = FindObjectOfType<EnemySpawner>().enemiesInPlay;
        foreach(Enemy enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().levelLost = true;
        }
        foreach (Enemy enemy in enemies.ToArray())
        {
            enemy.ExploadOnGameOver();
            yield return new WaitForSeconds(0.5f);
        }
        while (enemies.Count != 0) { yield return null; }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

}
