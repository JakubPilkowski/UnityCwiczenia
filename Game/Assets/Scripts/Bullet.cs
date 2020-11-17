using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public Rigidbody2D rb;

    public Character Owner
    {
        get; 
        set;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Debug.Log("Bullet hit " +hitInfo.gameObject.tag);
        
        switch (hitInfo.gameObject.tag)
        {
            case "Player":
                hitInfo.GetComponent<Player>().TakeDamage(Owner.damage);
                break;
            case "Enemy":
                if (Owner.GetType() == typeof(Enemy))
                    return;
                else
                {
                    hitInfo.GetComponent<Enemy>().TakeDamage(Owner.damage);  
                }
                break;
            case "DestroyableWall":
                if (Owner.GetType() == typeof(Player))
                {
                    hitInfo.GetComponent<Wall>().TakeDamage(Owner.damage);
                }
                break;
        }
        Destroy(gameObject);
    }
}
