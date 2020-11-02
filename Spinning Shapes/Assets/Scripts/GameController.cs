using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

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

    [Header("Score")]
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI highestScore = null;

    [Header("Other")]
    [SerializeField] TextMeshProUGUI speedText = null;
    [SerializeField] GameObject loseCanvas = null;
    [SerializeField] AudioClip loseSound = null;
    [SerializeField] [Range(0,1)] float loseSoundVolume = 0.5f;
    [SerializeField] Animator beatAnim = null;
    [SerializeField] float gameSpeed = 1.0f; // Debug purposes

    float cameraRotationSign;
    bool isDead = false;

    private void Start()
    {
        ChangeCameraBackgroundColor();
        SetSpeedText(gameSpeed);
        InvokeRepeating("RandomSign", spinDirectionChangeTime, spinDirectionChangeTime);
    }
    private void Update()
    {
        RotateCamera();
    }

    public void Lose()
    {
        isDead = true;
        ManageHighestScore();
        AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position, loseSoundVolume);
        loseCanvas.SetActive(true);
        highestScore.text = PlayerPrefs.GetInt("HighestScore", 0).ToString();
        Time.timeScale = 0f;
    }
    public void SpeedUpTheGame(float amountToSpeed)
    {
        if (!isDead)
        {
            Time.timeScale += amountToSpeed;
            gameSpeed = Time.timeScale;
            SetSpeedText(gameSpeed);
        }
    }

    private void SetSpeedText( float amount)
    {
        if (amount % 1 == 0)
            speedText.text = "x" + amount.ToString() + ".00";
        else
        {
            speedText.text = "x" + amount.ToString().Replace(",", ".");
        }
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

    private void RotateCamera()
    {
        float rotationFactor = Time.deltaTime * spinSpeed * cameraRotationSign;

        gameCamera.transform.Rotate(0f, 0f, rotationFactor);
        FindObjectOfType<Player>().RotatePlayerBy(rotationFactor); // counter rotation for player while camera rotates
    }

    private void RandomSign()
    {
        cameraRotationSign = (Random.Range(0, 2) - 0.5f) * 2;
    }
    #endregion

    #region Getters
    public float GetPlayerMoveSpeed() { return playerMoveSpeed; }
    public float GetShapeShrinkSpeed() { return shapeShrinkSpeed; }
    public float GetTimeBetweenShapeSpawns() { return timeBetweenShapeSpawns; }
    public GameObject[] GetShapePrefabs() { return shapePrefabs; }
    public int GetScore() { return score; }
    public Animator GetBeatAnimator() { return beatAnim; }

    #endregion
}
