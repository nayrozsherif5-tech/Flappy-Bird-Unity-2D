using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

     public Rigidbody2D myRigidbody;
     public float flapStrength;
     public LogicScript logic;
     public bool birdIsAlive = true;
     public AudioSource flap;
     public AudioSource col;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) 
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            flap.Play();

        }

        if(transform.position.y > 16 || transform.position.y < -16)
        {
            birdIsAlive = false;
            logic.gameOver();
            gameObject.SetActive(false);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        logic.gameOver();
        col.Play();
    }
}
