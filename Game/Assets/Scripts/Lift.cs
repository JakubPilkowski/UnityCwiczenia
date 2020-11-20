using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public float elevatorSpeed = 4f;
    private bool isRunning = false;
    public float distance = 4.5f;
    private bool isRunningToEnd = true;
    private bool isRunningToStart = false;
    private float xStartPosition;
    private float xEndPosition;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        xEndPosition = transform.position.y + distance;
        xStartPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunningToEnd && transform.position.y >= xEndPosition)
        {
            isRunning = false;
            
            Vector3 move = transform.position;
            move.y = xEndPosition;
            transform.position = move;
        }
        else if (isRunningToStart && transform.position.y <= xStartPosition)
        {
            isRunning = false;
            
            Vector3 move = transform.position;
            move.y = xStartPosition;
            transform.position = move;
            
        }

        if (isRunning)
        {
            Vector3 move = transform.up;
            if (isRunningToEnd)
            {
                move = transform.up * elevatorSpeed * Time.deltaTime;
            }
            else if(isRunningToStart)
            {
                move = -transform.up * elevatorSpeed * Time.deltaTime;
            }
            transform.Translate(move);
            if (player != null)
            {
                player.transform.Translate(move);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            isRunningToStart = false;
            isRunningToEnd = true;
            isRunning = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
            isRunningToEnd = false;
            isRunningToStart = true;
            player = null;
        }
    }
}
