using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealth : ConsumeAction {



    public override bool Consume(Item item) {
        PlayerStats.instance.currentHP = 
				Mathf.Min(PlayerStats.instance.maxHP, PlayerStats.instance.currentHP+item.restorationValue);
		return true;
    }
}
