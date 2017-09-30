using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InventorySlot))]
public class SlotHandler : MonoBehaviour, IDropHandler {

	public GameObject item {
		get { if (transform.childCount > 0){
				return transform.GetChild(0).gameObject;
			}
			return null; 
			}
	}

	private DragHandler dragHandler;
	private InventoryHandler inventory;
	private InventorySlot slot;


    // Use this for initialization
    void Start () {
		inventory = InventoryHandler.instance;
		slot = GetComponent<InventorySlot>();
	}


    void IDropHandler.OnDrop(PointerEventData eventData) {
		if (DragHandler.itemBeingDragged != null) {
        	int startID = DragHandler.itemBeingDragged.GetComponent<DragHandler>().slotID;
			inventory.SwapItems(startID,slot.id);
		}
    }
}
