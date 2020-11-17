using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{

    public float hp = 75;
    [SerializeField] private TextMeshPro wallHpText;

    private float maxHp;
    void Start()
    {
        maxHp = hp;
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        wallHpText.text = hp + "/" + maxHp;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
