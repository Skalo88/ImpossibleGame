using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float jumpForce = 1000;
    bool inAir = false;
    public float rotationSpeed = 10;
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           //Jump Logic
           if (!inAir)
           {
            rigidbody2D.AddForceAtPosition(Vector2.up * jumpForce, transform.position); 
    
           }
        }

        if (inAir)
        {
            //rotate slowly
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //reset all position
            gameManager.ResetPosition();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        inAir = true;
    }
}