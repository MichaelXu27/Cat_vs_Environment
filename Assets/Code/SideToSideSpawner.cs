using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideSpawner : MonoBehaviour
{
    //outlets
    public GameObject[] sideToSidePrefabs;
    public float spawnInterval;
    public float minimumInterval;
    public float rampUpRate ;

    float groundY = -3f;
    float leftX = -18.5f;
    float rightX = 18.5f;

    private bool hasStartedSpawning = false;

    void Update()
    {
        if (!hasStartedSpawning)
        {
            if (ScoreManager.instance.score >= 5)
            {
                hasStartedSpawning = true;
                StartCoroutine(SpawnObjects());
            }
        }
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            SpawnSideToSideObject();
            yield return new WaitForSeconds(spawnInterval);

            // decrease the spawnInterval, but do not go below the minimumInterval
            spawnInterval = Mathf.Max(minimumInterval, spawnInterval - rampUpRate);
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
