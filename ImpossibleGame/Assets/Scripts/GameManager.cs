using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float movementSpeed = 6;
    public GameObject levelGroup;
    public Vector3 lastCheckpoint = new Vector3 (0, 0, 0);
    public GameObject player;
    public Text attemptText;
    public int numberOfAttempts = 1;
    bool canReset = true;

    public void ResetPosition()
    {
        if(canReset)
        {
            canReset = false;
            //stop time for 1sec
            Time.timeScale = 0;
            StartCoroutine(DelayOnDeath());
        }
    }

    public void UpdateCheckpoint(Vector3 newCheckpoint)
    {
        lastCheckpoint = newCheckpoint;
    }

    IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(0.01f);
        canReset = true;
    }


    IEnumerator DelayOnDeath()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        levelGroup.transform.position = new Vector3(lastCheckpoint.x, 0 , 0);
        player.transform.position = new Vector3(player.transform.position.x, lastCheckpoint.y, 0);
        numberOfAttempts++;
        attemptText.text = "Attempts: " + numberOfAttempts;
        canReset = false;
        StartCoroutine(ResetCoolDown());
    }
}
