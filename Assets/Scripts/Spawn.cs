using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Vector2 timeBetweenSpawn;
    float nextSpawnTime;

    public GameObject spawnPrefab;
    public Vector2 blockSizeMinMax;
    public float maxAngle;
    Vector2 screenHalfWidthInWorldUnits;

    private void Start()
    {
        screenHalfWidthInWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,
            Camera.main.orthographicSize);
    }

    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            float secondsBetweenSpanws = Mathf.Lerp(timeBetweenSpawn.y, timeBetweenSpawn.x, Difficulty.GetMaxDifficulty());
            nextSpawnTime = Time.time + secondsBetweenSpanws;
            float spawnSize = Random.Range(blockSizeMinMax.x, blockSizeMinMax.y);
            float angle = Random.Range(-maxAngle, maxAngle);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfWidthInWorldUnits.x,
                screenHalfWidthInWorldUnits.x), screenHalfWidthInWorldUnits.y + spawnSize);
            GameObject newBlock = Instantiate(spawnPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * angle));
            newBlock.transform.localScale = Vector2.one * spawnSize;

        }
    }
}
