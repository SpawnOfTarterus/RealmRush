using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    float levelTransitionTime = 3f;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        var enemies = FindObjectOfType<EnemySpawner>().enemiesInPlay;
        foreach(Enemy enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().levelLost = true;
        }
        yield return new WaitForSeconds(levelTransitionTime);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

}
