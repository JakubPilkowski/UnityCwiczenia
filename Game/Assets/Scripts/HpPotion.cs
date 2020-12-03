using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : Potion
{

    public float healAmount;

    public override void OnTriggerWithPlayer(Player player)
    {
        player.HealCharacter(healAmount);
        Destroy(gameObject);
    }
}
