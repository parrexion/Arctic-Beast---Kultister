using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InventorySlot))]
public class ConsumeHandler : MonoBehaviour, IPointerDownHandler {

	public GameObject item {
		get { if (transform.childCount > 0){
				return transform.GetChild(0).gameObject;
			}
			return null; 
			}
	}

	private InventoryHandler inventory;
	private InventorySlot slot;


    // Use this for initialization
    void Start () {
		inventory = InventoryHandler.instance;
		slot = GetComponent<InventorySlot>();
	}

    public void OnPointerDown(PointerEventData eventData) {
		if (slot.itemType == Item.ItemType.CONSUME) {
        	bool used = slot.item.Use();
			if (used)
				inventory.RemoveItem(slot.id);
		}
    }
}
