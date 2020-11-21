using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Character
{
    private int kills = 0;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI damageMultiplierText;
    public TextMeshPro eventIndicator;

    void Start()
    {
        setMaxHp();
        eventIndicator.gameObject.SetActive(false);
        hpText.text = "Health: " + hp;
        killsText.text = "Kills: " + kills;
        damageMultiplierText.text = "Damage: " + damage;
    }

    public void AddKill(EnemyType type)
    {
        if(type == EnemyType.Normal)
        {
            kills++;
            killsText.text = "Kills: " + kills;
            eventIndicator.gameObject.SetActive(true);
            eventIndicator.color = new Color32(0, 191, 255, 255);
            eventIndicator.text = "Kill +1";
            StartCoroutine(HideEventIndicator());
        }
        if(type == EnemyType.Boss)
        {
            FindObjectOfType<GameManager>().Victory();
        }
    }

    IEnumerator HideEventIndicator()
    {
        yield return new WaitForSeconds(1);
        eventIndicator.gameObject.SetActive(false);
        StopCoroutine(HideEventIndicator());
    }

    public void AddMultiplier(float value)
    {
        damage += value;
        damageMultiplierText.text = "Damage: " + damage;
        eventIndicator.gameObject.SetActive(true);
        eventIndicator.color = new Color32(255, 215, 0, 255);
        eventIndicator.text = "Damage +"+value;
        StartCoroutine(HideEventIndicator());
    }

    public override void onDie()
    {
        FindObjectOfType<GameManager>().GameOver();
    }

    public override void onHeal(float amount)
    {
        hpText.text = "Health: " + hp;
        eventIndicator.gameObject.SetActive(true);
        eventIndicator.color = new Color32(0, 255, 0, 255);
        eventIndicator.text = "+"+amount+"HP";
        StartCoroutine(HideEventIndicator());
    }

    public override void onTakeDamage(float amount)
    {
        hpText.text = "HP: " + hp;
        eventIndicator.gameObject.SetActive(true);
        eventIndicator.color = new Color32(255, 0, 0, 255);
        eventIndicator.text = "-"+amount+"HP";
        StartCoroutine(HideEventIndicator());
    }
}
