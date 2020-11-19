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
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        xEndPosition = transform.position.y + distance;
        xStartPosition = transform.position.y;
        Debug.Log("start position " + xStartPosition);
        Debug.Log("end position "+xEndPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunningToEnd && transform.position.y >= xEndPosition)
        {
            isRunning = false;
            
            Vector2 move = transform.position;
            move.y = xEndPosition;
            transform.position = move;
        }
        else if (isRunningToStart && transform.position.y <= xStartPosition)
        {
            isRunning = false;
            
            Vector2 move = transform.position;
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
            player.transform.Translate(move);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player trigger lift");
            /*
            if (transform.position.y == xEndPosition)
            {
                isRunningToStart = true;
            }
            else if(transform.position.y == xStartPosition)
            {
                isRunningToEnd = true;
            }
            */

            isRunningToStart = false;
            isRunningToEnd = true;
            isRunning = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player trigger exit lift");
            /*
            Debug.Log("Transform y" + transform.position.y);
            if (transform.position.y == xEndPosition)
            {
                Debug.Log("Transform y" + transform.position.y);
                isRunningToStart = true;
                isRunning = true;
            }
            else
            {
            */
            isRunning = true;
            isRunningToEnd = false;
            isRunningToStart = true;
            //}
        }
    }
}
