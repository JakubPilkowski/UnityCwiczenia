﻿using System.Collections;
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

    [SerializeField] private Transform doors;

    void Start()
    {
        positionClosed = doors.position.y;
        positionOpened = doors.position.y + doors.localScale.y*2;
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
        if (collider.gameObject.CompareTag("Player"))
        {
            isOpening = true;
            isClosing = false;
            isAnimating = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    { 
        if (collider.gameObject.CompareTag("Player"))
        {
            isOpening = false;
            isClosing = true;
            isAnimating = true;
        }
        
    }
}
