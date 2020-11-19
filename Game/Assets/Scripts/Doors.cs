using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Start is called before the first frame update
    public float openingSpeed = 1.0f;

    private bool isOpening = false;
    private bool isClosing = false;
    private bool isAnimating = false;
    private float positionOpened;
    private float positionClosed;

    [SerializeField] Transform doors;

    void Start()
    {
        positionClosed = doors.position.y;
        positionOpened = doors.position.y + doors.localScale.y*2;
        Debug.Log("Closed" + positionClosed);
        Debug.Log("Opened" + positionOpened);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening && doors.position.y >= positionOpened)
        {
            isOpening = false;
            isAnimating = false;
            Vector2 move = doors.position;
            move.y = positionOpened;
            doors.position = move;
        }
        else if (isClosing && doors.position.y <= positionClosed)
        {
            isClosing = false;
            isAnimating = false;
            Vector2 move = doors.position;
            move.y = positionClosed;
            doors.position = move;
        }

        if (isAnimating)
        {
            Vector2 move = doors.up;
            if (isOpening)
            {
                move = doors.up * openingSpeed * Time.deltaTime;
            }
            else if (isClosing)
            {
                move = -doors.up * openingSpeed * Time.deltaTime;
            }
            doors.Translate(move);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("TagEnter " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player enter");
            isOpening = true;
            isClosing = false;
            isAnimating = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("TagExit " + collider.gameObject.tag);

        
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exit");
            isOpening = false;
            isClosing = true;
            isAnimating = true;
        }
        
    }
}
