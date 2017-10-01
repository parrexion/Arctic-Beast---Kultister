using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Actions/Consume Heal")]
public class ConsumeHealAction : ConsumeAction {


	public override bool Consume(Item item)
    {
        PlayerStats.instance.currentHP = 
				Mathf.Min(PlayerStats.instance.maxHP, PlayerStats.instance.currentHP+item.restorationValue);
		return true;
    }
}
