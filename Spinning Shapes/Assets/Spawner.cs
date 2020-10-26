using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timeBetweenSpawns;
    GameObject[] shapePrefabs;
    GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timeBetweenSpawns = gameController.GetTimeBetweenShapeSpawns();
        shapePrefabs = gameController.GetShapePrefabs();
        InvokeRepeating("Spawn", timeBetweenSpawns, timeBetweenSpawns);
    }

    void Spawn()
    {
        int shapeIndex = Random.Range(0, shapePrefabs.Length);
        Instantiate(shapePrefabs[shapeIndex], new Vector2(0.0f, 0.0f), Quaternion.identity);
    }
}
