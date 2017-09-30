using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject {

	public enum ItemType {EQUIP,CONSUME,OTHER}

	public ItemType type;
	public Sprite icon;
}
