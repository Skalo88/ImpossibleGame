using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementController : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-gameManager.movementSpeed * Time.deltaTime, 0, 0);
    }
}
