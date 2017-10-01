using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour {

	public int id = 0;
	public Image image;
	public Item.ItemType itemType;

	public Item item;


	public void SetItem(Item newItem){
		item = newItem;

		image.sprite = item.icon;
		image.enabled = true;
	}

	public void RemoveItem(){
		item = null;
		image.enabled = false;
	}
}
