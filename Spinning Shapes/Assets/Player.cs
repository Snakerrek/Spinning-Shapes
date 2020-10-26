using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed;
    private void Start()
    {
        moveSpeed = FindObjectOfType<GameController>().GetPlayerMoveSpeed();
    }

    void FixedUpdate()
    {
        if(Input.GetKey("a"))
            transform.RotateAround(Vector3.zero, Vector3.forward, moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey("d"))
            transform.RotateAround(Vector3.zero, Vector3.forward, -moveSpeed * Time.fixedDeltaTime);
    }
}
