using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] float playerMoveSpeed = 500f;
    [SerializeField] float shapeShrinkSpeed = 3.0f;
    [SerializeField] float timeBetweenShapeSpawns = 2.0f;
    [SerializeField] GameObject[] shapePrefabs = null;


    public float GetPlayerMoveSpeed()
    {
        return playerMoveSpeed;
    }
    public float GetShapeShrinkSpeed()
    {
        return shapeShrinkSpeed;
    }

    public float GetTimeBetweenShapeSpawns()
    {
        return timeBetweenShapeSpawns;
    }

    public GameObject[] GetShapePrefabs()
    {
        return shapePrefabs;
    }
}
