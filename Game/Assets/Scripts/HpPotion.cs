using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : Potion
{
    // Start is called before the first frame update

    public float healAmount;

    public override void OnTriggerWithPlayer(Player player)
    {
        player.HealCharacter(healAmount);
        Destroy(gameObject);
    }
}
