using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : Potion
{
    public float value = 5;

    public override void OnTriggerWithPlayer(Player player)
    {
        player.AddMultiplier(value);
        Destroy(gameObject);
    }
}
