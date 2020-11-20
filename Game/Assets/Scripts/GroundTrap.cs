using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrap : MonoBehaviour
{

    private Player player;
    private Movement movement;
    public GameObject playerObject;
    public float damage = 25;


    void OnTriggerEnter2D(Collider2D collider)
    {

        player = collider.GetComponent<Player>();
        movement = collider.GetComponent<Movement>();
        if (player != null && movement != null)
        {
            StartCoroutine(DamageAfterDelay());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(player != null && movement != null)
        {
            player = null;
            movement = null;
            StopCoroutine(DamageAfterDelay());
        }
    }

    IEnumerator DamageAfterDelay()
    {
        if(player != null && movement != null)
        {
            player.TakeDamage(damage);
            if(player != null)
            {
                movement.jump = true;
            }
        }
        yield return new WaitForSeconds(1f);
        if (player != null && movement != null)
        {
            player.TakeDamage(damage);
            if (player != null)
            {
                movement.jump = true;
            }
        }
        else
        {
            StopCoroutine(DamageAfterDelay());
        }
    }
}
