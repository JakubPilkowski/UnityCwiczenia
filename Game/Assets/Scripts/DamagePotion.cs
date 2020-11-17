using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : Potion
{
    // Start is called before the first frame update
    public override void OnTriggerWithPlayer(Player player)
    {
        player.AddMultiplier();
        Destroy(gameObject);
    }
}
