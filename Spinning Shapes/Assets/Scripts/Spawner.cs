using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timeBetweenSpawns;
    GameObject[] shapePrefabs;
    GameController gameController;

    int shapeIndex;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timeBetweenSpawns = gameController.GetTimeBetweenShapeSpawns();
        shapePrefabs = gameController.GetShapePrefabs();
        shapeIndex = Random.Range(0, shapePrefabs.Length); // Deciding what shape will be used for single game session
        InvokeRepeating("Spawn", timeBetweenSpawns, timeBetweenSpawns);
    }

    void Spawn()
    {
        Instantiate(shapePrefabs[shapeIndex], new Vector2(0.0f, 0.0f), Quaternion.identity);
    }
}
