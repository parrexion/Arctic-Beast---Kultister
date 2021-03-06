﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	private InventoryHandler inventory;
	private InventorySlot[] equippedItemsUI;
	private InventorySlot[] otherItemsUI;

	public Transform equippedContainer;
	public Transform otherContainer;

	public Image noChangePanel;

	// Use this for initialization
	void Start () {
		inventory = InventoryHandler.instance;
		inventory.onItemChangedCallback += UpdateUI;

		equippedItemsUI = equippedContainer.GetComponentsInChildren<InventorySlot>();
		for (int i = 0; i < equippedItemsUI.Length; i++) {
			equippedItemsUI[i].id = 100 + i;
		}

		otherItemsUI = otherContainer.GetComponentsInChildren<InventorySlot>();
		for (int i = 0; i < otherItemsUI.Length; i++) {
			otherItemsUI[i].id = i;
		}

		noChangePanel.enabled = (PlayerStats.instance.currentLocation != 0);
		UpdateUI();
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
				equippedItemsUI[i].SetItem(inventory.GetItem(100+i));
			}
			else {
				equippedItemsUI[i].RemoveItem();
			}
		}
		for (int i = 0; i < otherItemsUI.Length; i++) {
			if (inventory.otherItems[i] != null){
				otherItemsUI[i].SetItem(inventory.otherItems[i]);
				Debug.Log("Found item");
			}
			else {
				otherItemsUI[i].RemoveItem();
			}
		}
		Debug.Log("Updated!");
	}
}
