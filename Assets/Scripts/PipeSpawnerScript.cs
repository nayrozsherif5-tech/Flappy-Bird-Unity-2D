using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    float timer = 0;
    public float heightOffset = 10;

    void Start()
    {
        SpwanPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpwanPipe();
            timer = 0;
        }
    }


    void SpwanPipe()
    {
        float lowesPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowesPoint,heightOffset), 0), transform.rotation);
    }
}