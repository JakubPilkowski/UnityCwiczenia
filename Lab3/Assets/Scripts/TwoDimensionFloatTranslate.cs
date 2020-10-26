using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionFloatTranslate : MonoBehaviour
{

    public float speed = 1;

    private string direction = "right";

    private Vector3 cubeRight = new Vector3(10f, 0.5f, 0f);
    private Vector3 cubeUp = new Vector3(10f, 0.5f, 10f);
    private Vector3 cubeLeft = new Vector3(0f, 0.5f, 10f);
    private Vector3 cubeDown = new Vector3(0f, 0.5f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // cubeTranslate();
        // cubeRotate();
        // changeDirection();
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(10f, 0.75f, 0.5f), speed * Time.deltaTime);

        float maxDegreesDelta = speed * 10 * Time.deltaTime;
        switch (direction)
        {
            case "right":
                transform.position = Vector3.MoveTowards(transform.position, cubeRight, speed * Time.deltaTime);
                if (transform.position == cubeRight)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,90,0), maxDegreesDelta);
                }
                if(transform.localEulerAngles.y==90)
                {
                    direction = "up";
                }
                break;
            case "up":
                transform.position = Vector3.MoveTowards(transform.position, cubeUp, speed * Time.deltaTime);
                if (transform.position == cubeUp)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180, 0), maxDegreesDelta);
                }
                if (transform.localEulerAngles.y == 180)
                {
                    direction = "left";
                }
                break;
            case "left":
                transform.position = Vector3.MoveTowards(transform.position, cubeLeft, speed * Time.deltaTime);
                if (transform.position == cubeLeft)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 270, 0), maxDegreesDelta);
                }
                if (transform.localEulerAngles.y == 270)
                {
                    direction = "down";
                }
                break;
            case "down":
                transform.position = Vector3.MoveTowards(transform.position, cubeDown, speed * Time.deltaTime);
                if (transform.position == cubeDown)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), maxDegreesDelta);
                }
                if (transform.rotation.y == 0)
                {
                    direction = "right";
                }
                break;
        }
    }
}
