using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float playerMoveSpeed = 500f;

    [Header("Shapes Settings")]
    [SerializeField] float shapeShrinkSpeed = 3.0f;
    [SerializeField] float timeBetweenShapeSpawns = 2.0f;
    [SerializeField] GameObject[] shapePrefabs = null;

    [Header("Camera Settings")]
    [SerializeField] GameObject gameCamera = null;
    [SerializeField] Gradient cameraColorGradient = null;
    [SerializeField] float spinDirectionChangeTime = 2.0f;
    [SerializeField] float spinSpeed = 1.0f;
    float cameraRotationSign;

    [Header("Score")]
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        InvokeRepeating("RandomSign", spinDirectionChangeTime, spinDirectionChangeTime);
    }
    private void Update()
    {
        RotateCamera();
    }

    #region Score Methods

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText(score);
    }

    public void ManageHighestScore()
    {
        if (PlayerPrefs.GetInt("HighestScore", 0) < score)
            PlayerPrefs.SetInt("HighestScore", score);
    }

    void UpdateScoreText(int amount)
    {
        scoreText.text = amount.ToString();
    }

    #endregion

    #region Camera Methods
    public void ChangeCameraBackgroundColor()
    {
        gameCamera.GetComponent<Camera>().backgroundColor = cameraColorGradient.Evaluate(Random.Range(0f, 1f));
    }

    void RotateCamera()
    {
        gameCamera.transform.Rotate(0f, 0f, Time.deltaTime * spinSpeed * cameraRotationSign);
    }

    void RandomSign()
    {
        cameraRotationSign = (Random.Range(0, 2) - 0.5f) * 2;
        Debug.Log(cameraRotationSign);
    }
    #endregion

    #region Getters
    public float GetPlayerMoveSpeed() { return playerMoveSpeed; }
    public float GetShapeShrinkSpeed() { return shapeShrinkSpeed; }
    public float GetTimeBetweenShapeSpawns() { return timeBetweenShapeSpawns; }
    public GameObject[] GetShapePrefabs() { return shapePrefabs; }
    public int GetScore() { return score; }

    #endregion
}
