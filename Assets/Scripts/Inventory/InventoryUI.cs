using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

	InventoryHandler inventory;
	InventorySlot[] equippedItemsUI;
	InventorySlot[] otherItemsUI;

	Transform equippedContainer;
	Transform otherContainer;

	// Use this for initialization
	void Start () {
		inventory = InventoryHandler.instance;
		inventory.onItemChangedCallback += UpdateUI;

		equippedItemsUI = equippedContainer.GetComponentsInChildren<InventorySlot>();
		for (int i = 0; i < equippedItemsUI.Length; i++) {
			equippedItemsUI[i].id = 101 + i;
		}

		otherItemsUI = otherContainer.GetComponentsInChildren<InventorySlot>();
		for (int i = 0; i < otherItemsUI.Length; i++) {
			otherItemsUI[i].id = 101 + i;
		}
	}

	void OnDisable() {
		inventory.onItemChangedCallback -= UpdateUI;
	}
	
	// Update is called once per frame
	void UpdateUI () {
		if (!inventory.initialized)
			return;
		
		for (int i = 0; i < equippedItemsUI.Length; i++) {
			if (inventory.equippedItems[i] != null){
				equippedItemsUI[i].SetItem(inventory.GetItem(101+i));
			}
			else {
				equippedItemsUI[i].RemoveItem();
			}
		}
		for (int i = 0; i < otherItemsUI.Length; i++) {
			if (inventory.otherItems[i] != null){
				otherItemsUI[i].SetItem(inventory.GetItem(101+i));
			}
			else {
				otherItemsUI[i].RemoveItem();
			}
		}
	}
}
