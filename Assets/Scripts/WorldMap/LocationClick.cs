using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class LocationClick : MonoBehaviour, IPointerClickHandler {

	[HideInInspector] public MapPanelSetup mapPanel;
	public Sprite[] toggleSprites;
	public int id = -1;
	public int backID = -1;

	public Location location;

	private Image image;
	private bool available = false;

    // Use this for initialization
    void Start () {
		image = GetComponent<Image>();
		SetAvailable(PlayerStats.instance.currentLocation);
	}
	

    public void OnPointerClick(PointerEventData eventData) {
		if (location != null && location.exits.Count > 0)
			mapPanel.ClickLocation(id, location.exits[0].id);
    }

	private void SetAvailable(int clickedID){
		available = clickedID == id ||clickedID == backID;

		if (available) {
        	image.sprite = toggleSprites[1];
			image.color = Color.white;
		}
		else {
			image.sprite = toggleSprites[0];
			image.color = Color.grey;
		}
	}

	public bool SetGoLocation(int clickedID, int nextID){

		if (available && id == clickedID){
			image.color = Color.green;
			LevelSpec.instance.levelID = id;
			LevelSpec.instance.nextLevelID = nextID;
			return true;
		}
		else if (available){
			image.color = Color.white;
			return false;
		}
		else {
			image.color = Color.grey;
			return false;
		}
	}
}
