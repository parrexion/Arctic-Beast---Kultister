using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {

	#region Singleton
	public static InventoryHandler instance = null;
	void Awake(){
		if (instance != null)
			Destroy(gameObject);
		else
			instance = this;
	}
	#endregion

	public bool initialized = false;

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int equipInventorySize = 4;
	public int otherInventorySize = 12;

	public Item rune;
	public Item[] equippedItems;
	public Item[] otherItems;

	public Item[] testItems;


	// Use this for initialization
	void Start () {
		equippedItems = new Item[equipInventorySize];
		otherItems = new Item[otherInventorySize];
		initialized = true;
		FillDefault();
	}


	private void FillDefault(){
		for (int i = 0; i < testItems.Length; i++)	{
			Item test = ScriptableObject.Instantiate(testItems[i]);
			AddItem(test);
		}
	}

	public void SetRune(Item runeItem){
		rune = runeItem;
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	public bool AddItem(Item item){
		int startIndex = 0;
		Item.ItemType type = item.type;
		if (type == Item.ItemType.CONSUME)
			startIndex = otherInventorySize / 2;
		for (int i = startIndex; i < otherInventorySize; i++){
			if (otherItems[i] == null){
				otherItems[i] = item;
				Debug.Log("Item added to inventory!  " + i);
				if (onItemChangedCallback != null)
					onItemChangedCallback.Invoke();
				return true;
			}	
		}
		Debug.Log("Inventory is full!");
		return false;
	}

	public bool HasTool(string toolName){
		for (int i = 0; i < equippedItems.Length; i++) {
			if (equippedItems[i].itemName == toolName)
			return true;
		}
		return false;
	}

	public void RemoveItem(int id){
		SetItem(id,null);
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	public void SwapItems(int startID, int endID) {
		Debug.Log("SWAPPY!  " + startID + " , " + endID);
		Item temp = GetItem(startID);
		SetItem(startID, GetItem(endID));
		SetItem(endID, temp);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	public Item GetItem(int id) {
		if (id >= 100){
			return equippedItems[id-100];
		}
		return otherItems[id];
	}

	private void SetItem(int id, Item item) {
		Debug.Log("ID: " + id);
		if (id >= 100){
			equippedItems[id-100] = item;
		}
		else
			otherItems[id] = item;
	}
}
