using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    void Start()
    {
        Time.timeScale = 1.0f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
