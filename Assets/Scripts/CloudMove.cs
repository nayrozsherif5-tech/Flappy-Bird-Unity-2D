using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float minSpeed = 0.8f;
    public float maxSpeed = 1.1f;
    public float minSize = 3f;     // make bigger: raise these two
    public float maxSize = 4f;

    private float speed;
    private SpriteRenderer sr;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        speed = Random.Range(minSpeed, maxSpeed);
        transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        float leftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        if (transform.position.x + sr.bounds.extents.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}