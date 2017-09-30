using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, 
							IEndDragHandler, IPointerClickHandler {

	public static GameObject itemBeingDragged = null;

	public InventorySlot itemSlot;
	public int slotID;

	private Image image;
    private GameObject inventoryParent;

    void Start(){
        image = GetComponent<Image>();
        inventoryParent = GetComponentInParent<SpriteRenderer>().gameObject;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) {
        itemBeingDragged = gameObject;
		slotID = itemSlot.id;
		image.raycastTarget = false;
		transform.parent.transform.SetAsLastSibling();
        inventoryParent.transform.SetAsLastSibling();
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
