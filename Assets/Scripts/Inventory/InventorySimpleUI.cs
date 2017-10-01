using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySimpleUI : MonoBehaviour {

	private InventoryHandler inventory;
	private InventorySlot[] equippedItemsUI;
	public InventorySlot runeSlot;

	public Transform equippedContainer;
	public Item noRune;

	// Use this for initialization
	void Start () {
		inventory = InventoryHandler.instance;
		inventory.onItemChangedCallback += UpdateUI;

		equippedItemsUI = equippedContainer.GetComponentsInChildren<InventorySlot>();
		for (int i = 0; i < equippedItemsUI.Length; i++) {
			equippedItemsUI[i].id = 100 + i;
		}
	}

	void OnDisable() {
		inventory.onItemChangedCallback -= UpdateUI;
	}
	
	// Update is called once per frame
	void UpdateUI () {
		if (!inventory.initialized)
			return;
		
		if (inventory.rune != null)
			runeSlot.SetItem(inventory.rune);
		else
			runeSlot.SetItem(noRune);

		for (int i = 0; i < equippedItemsUI.Length; i++) {
			if (inventory.equippedItems[i] != null){
				equippedItemsUI[i].SetItem(inventory.GetItem(100+i));
			}
			else {
				equippedItemsUI[i].RemoveItem();
			}
		}
		Debug.Log("Updated!");
	}
}
