using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipePrefab;
    public float spawnInterval = 2.0f;
    public float pipeHeightMin = 1.0f;
    public float pipeHeightMax = 4.0f;
    private float screenWidth;

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        InvokeRepeating("SpawnPipe", 0f, spawnInterval);
    }

    void SpawnPipe()
    {
        float pipeHeight = Random.Range(pipeHeightMin, pipeHeightMax);
        Vector3 spawnPosition = new Vector3(screenWidth + 1, pipeHeight, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
