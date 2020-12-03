using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp = 100;
    private float maxHp;
    public float damage;

    public float getMaxHp()
    {
        return maxHp;
    }

    public void setMaxHp()
    {
        maxHp = hp;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        onTakeDamage(damage);
        if (hp <= 0)
        {
            Die();
        }
    }

    public void HealCharacter(float amount)
    {
        if (hp+amount > maxHp)
        {
            float amountDiff = maxHp - hp;
            hp = maxHp;
            onHeal(amountDiff);
        }
        else
        {
            hp += amount;
            onHeal(amount);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        onDie();
    }

    public abstract void onDie();
    public abstract void onHeal(float hp);
    public abstract void onTakeDamage(float hp);
}
