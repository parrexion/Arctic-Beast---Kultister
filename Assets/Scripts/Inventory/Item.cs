using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Item")]
public class Item : ScriptableObject {

	public enum ItemType {EQUIP,CONSUME,OTHER}

	public string itemName;
	public ItemType type;
	public Sprite icon;

	public ConsumeAction consumeAction;
	public int restorationValue = 0;


	public bool Use(){
		if (consumeAction == null)
			return false;


		return consumeAction.Consume(this);
	}
}
