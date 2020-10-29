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
        if(Input.GetKey("a"))
            transform.RotateAround(Vector3.zero, Vector3.forward, moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey("d"))
            transform.RotateAround(Vector3.zero, Vector3.forward, -moveSpeed * Time.fixedDeltaTime);
    }

    public void RotatePlayerBy(float factor)
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, factor);
    }
}
