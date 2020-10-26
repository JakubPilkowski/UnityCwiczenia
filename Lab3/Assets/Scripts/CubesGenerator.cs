using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubesGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        

        HashSet<float> xPositions = new HashSet<float>();
        HashSet<float> yPositions = new HashSet<float>();

        System.Random random = new System.Random();
        while (xPositions.Count<10 || yPositions.Count < 10)
        {
            if (xPositions.Count < 10)
            {
                float value = random.Next(0, 19) * 5f - 47.5f;
               // if (!xPositions.Contains(value))
               // {
                    xPositions.Add(value);
               // }
            }
            if (yPositions.Count < 10)
            {
                float value = random.Next(0, 19) * 5f - 47.5f;
              //  if (!yPositions.Contains(value))
               // {
                    yPositions.Add(value);
               // }
            }
        }

        List<float> xs = new List<float>(xPositions);
        List<float> ys = new List<float>(yPositions);

        for (int i=0; i < xs.Count; i++)
        {
        Instantiate(myPrefab, new Vector3(xs[i], 2.5f, ys[i]), Quaternion.identity);
        }
    }
}
