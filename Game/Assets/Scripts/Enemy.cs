using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : Character
{
    public Player player;
    public float shootDelay = 1.5f;
    [SerializeField] public TextMeshPro hpText;

    void Start()
    {
        setMaxHp();
    }

    public override void onDie()
    {
        player.AddKill();
    }

    public override void onHeal(float amount)
    {
        hpText.text = hp + "/" + getMaxHp();
    }

    public override void onTakeDamage(float amount)
    {
        hpText.text = hp + "/" + getMaxHp();
        if(hp <= getMaxHp() / 2)
        {
            hpText.color = new Color32(255, 0, 0, 255);
        }
    }
}
