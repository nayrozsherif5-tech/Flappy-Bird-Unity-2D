using System.Collections.Generic;

using System.Collections;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] cloudPrefabs;
    public float minInterval = 2.5f;
    public float maxInterval = 4f;
    public int startingClouds = 3;
    public int lanes = 4;            // number of height levels

    private int lastLane = -1;

    IEnumerator Start()
    {
        Camera cam = Camera.main;
        float left = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float right = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float width = right - left;

        // clouds already on screen, evenly spread left to right
        for (int i = 0; i < startingClouds; i++)
        {
            float x = left + width * (i + 0.5f) / startingClouds + Random.Range(-1f, 1f);
            SpawnCloud(x);
        }

        // then new ones from the right edge
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
            SpawnCloud(right + 4f);
        }
    }

    void SpawnCloud(float x)
    {
        Camera cam = Camera.main;
        float bottom = cam.ViewportToWorldPoint(new Vector3(0, 0.1f, 0)).y;
        float top = cam.ViewportToWorldPoint(new Vector3(0, 0.9f, 0)).y;

        // pick a height lane different from the previous cloud
        int lane;
        do { lane = Random.Range(0, lanes); } while (lane == lastLane && lanes > 1);
        lastLane = lane;

        float laneHeight = (top - bottom) / lanes;
        float y = bottom + laneHeight * (lane + 0.5f) + Random.Range(-laneHeight * 0.25f, laneHeight * 0.25f);

        GameObject prefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];
        Instantiate(prefab, new Vector3(x, y, 0f), Quaternion.identity);
    }
}