using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    float shrinkSpeed;
    Rigidbody2D rb;
    GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        shrinkSpeed = gameController.GetShapeShrinkSpeed();
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = new Vector3(8f, 8f, 8f);
    }

    void Update()
    {
        Shrink();
    }

    void Shrink()
    {
        Vector3 scaleFactor = new Vector3(1.0f, 1.0f, 1.0f) * shrinkSpeed * Time.deltaTime;
        transform.localScale -= scaleFactor;

        if (transform.localScale.x <= 0.1f)
        {
            gameController.AddScore(1);
            gameController.ChangeCameraBackgroundColor();
            gameController.GetBeatAnimator().SetTrigger("Active");
            gameController.SpeedUpTheGame(0.01f);
            Destroy(gameObject);
        }
    }


}
