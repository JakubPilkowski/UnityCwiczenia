using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrap : MonoBehaviour
{
    // Start is called before the first frame update

    private Player player;
    private Movement movement;
    public GameObject playerObject;
    public float damage = 25;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trap trigger enter");
        player = collider.GetComponent<Player>();
        movement = collider.GetComponent<Movement>();
        if (player != null && movement != null)
        {
            Debug.Log("Trap hit Player");
            // player.TakeDamage(damage);
            StartCoroutine(DamageAfterDelay());
        }
    }

    /*
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(damageAfterDelay());
        }
    }
    */

        /*
    void OnTriggerStay2D(Collider2D collider)
    {
        if(player.hp <= 0)
        {
            player = null;
            movement = null;
        }
    }
    */

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Trap trigger enter");
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
