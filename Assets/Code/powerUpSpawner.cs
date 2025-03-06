using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    public GameObject[] powerup_prefabs; //array to hold all of the gameObjects
    public float spawnInterval = 9f;
    public float spawningY = 6f;
    public float mixX = -7.5f; //this is the farthest left of the screen
    public float maxX = 7.5f; //this is the farthest right of the screen
    
    void Start()
    {
        // delay first power-up spawn by 6 seconds
        InvokeRepeating(nameof(SpawnObject), 6f, spawnInterval);
    }
    
    void SpawnObject()
    {
        int index = Random.Range(0, powerup_prefabs.Length);
        float randomSpawnX = Random.Range(mixX, maxX);
        Vector2 spawnPos = new Vector2(randomSpawnX, spawningY);
        Instantiate(powerup_prefabs[index], spawnPos, Quaternion.identity);
    }
}