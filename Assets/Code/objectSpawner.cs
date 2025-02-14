using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public GameObject[] object_prefabs; //array to hold all of the gameObjects
    public float spawnInterval = 1f;
    public float spawningY = 6f;
    public float mixX = -7.5f; //this is the farthest left of the screen
    public float maxX = 7.5f; //this is the farthest right of the screen

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnObject()
    {
        int index = Random.Range(0, object_prefabs.Length);
        float randomSpawnX = Random.Range(mixX, maxX);
        Vector2 spawnPos = new Vector2(randomSpawnX, spawningY);
        Instantiate(object_prefabs[index], spawnPos, Quaternion.identity);
    }
}
