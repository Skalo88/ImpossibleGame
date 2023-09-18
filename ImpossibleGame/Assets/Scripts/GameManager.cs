using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float movementSpeed = 6;
    public GameObject levelGroup;

    public void ResetPosition()
    {
        levelGroup.transform.position = Vector3.zero;
    }
}
