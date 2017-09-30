﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Item")]
public class Item : ScriptableObject {

	public enum ItemType {EQUIP,CONSUME,OTHER}

	public string itemName;
	public ItemType type;
	public Sprite icon;
}
