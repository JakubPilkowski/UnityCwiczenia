using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTranslate : MonoBehaviour
{

    public float speed = 1;
    private bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!reverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(10f, 0.5f, 0f), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0.5f, 0f), speed * Time.deltaTime);
        }
        if (transform.position.x == 10)
        {
            reverse = !reverse;
        }
    }
}
