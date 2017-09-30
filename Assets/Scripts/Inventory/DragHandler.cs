using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, 
							IEndDragHandler, IPointerClickHandler {

	public static GameObject itemBeingDragged = null;

	public InventorySlot itemSlot;
	private Image image;
	public int slotID;


    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) {
        itemBeingDragged = gameObject;
		slotID = itemSlot.id;
		image.raycastTarget = false;
		transform.parent.transform.SetAsLastSibling();
    }

    void IDragHandler.OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData) {
        itemBeingDragged = null;
		image.raycastTarget = true;
		transform.localPosition = Vector3.zero;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData) {
        
    }
}
