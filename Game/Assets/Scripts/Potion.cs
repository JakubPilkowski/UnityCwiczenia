using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    private float positionYstart;
    private float positionYend;
    public float speed = 1;

    private bool toEnd = true;
    private bool toStart = false;
    void Start()
    {
        positionYstart = transform.position.y - transform.localScale.y / 4;
        positionYend = transform.position.y + transform.localScale.y / 4;
    }
    void Update()
    {
        if (toEnd && transform.position.y >= positionYend)
        {
            toStart = true;
            toEnd = false;
        }
        else if (toStart && transform.position.y <= positionYstart)
        {
            toEnd = true;
            toStart = false;
        }

        Vector3 move = transform.up * speed * Time.deltaTime;
        move = toStart ? -move : move;
        transform.Translate(move);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            OnTriggerWithPlayer(player);
        }
    }

    public abstract void OnTriggerWithPlayer(Player player);
}
