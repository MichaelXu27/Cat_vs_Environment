using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideSpawner : MonoBehaviour
{
    public GameObject[] sideToSidePrefabs;
    public float spawnInterval = 2f;

    public float groundY = -3f;
    public float leftX = -18.5f;
    public float rightX = 18.5f;

    private bool hasStartedSpawning = false;

    void Update()
    {
        if (!hasStartedSpawning)
        {
            if (ScoreManager.instance.score >= 5)
            {
                hasStartedSpawning = true;
                InvokeRepeating(nameof(SpawnSideToSideObject), 0f, spawnInterval);
            }
        }
    }

    void SpawnSideToSideObject()
    {
        bool spawnOnLeft = Random.value > 0.5f;

        int index = Random.Range(0, sideToSidePrefabs.Length);

        float spawnX;
        if (spawnOnLeft)
        {
            spawnX = leftX;
        }
        else
        {
            spawnX = rightX;
        }

        Vector3 spawnPos = new Vector3(spawnX, groundY, 0f);

        GameObject spawnedObj = Instantiate(sideToSidePrefabs[index], spawnPos, Quaternion.identity);

        SideToSideMovement movementScript = spawnedObj.GetComponent<SideToSideMovement>();
        if (movementScript != null)
        {
            if (spawnOnLeft)
            {
                movementScript.speed = Mathf.Abs(movementScript.speed); 
            }
            else
            {
                movementScript.speed = -Mathf.Abs(movementScript.speed); 
            }
        }
    }
}
