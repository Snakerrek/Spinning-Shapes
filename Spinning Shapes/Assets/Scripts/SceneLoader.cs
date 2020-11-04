using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transition = null;

    public void ReloadScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoadLevel("Start Scene"));
    }

    public void LoadGame()
    {
        StartCoroutine(LoadLevel("Game"));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName);
    }
}
