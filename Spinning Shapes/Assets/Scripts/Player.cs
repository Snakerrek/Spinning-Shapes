using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed;
    GameController gameController;
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        moveSpeed = gameController.GetPlayerMoveSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.Lose();
    }
    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(touchPos.x < 0)
                transform.RotateAround(Vector3.zero, Vector3.forward, moveSpeed * Time.fixedDeltaTime);
            else
                transform.RotateAround(Vector3.zero, Vector3.forward, -moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void RotatePlayerBy(float factor)
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, factor);
    }
}
