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
		if (location != null){
			int next = (location.exits.Count > 0) ? location.exits[0].id : -1;
			mapPanel.ClickLocation(id, next);
		}
    }

	public void SetAvailable(int clickedID){
		available = (clickedID == backID);

		if (clickedID != -1 || !PlayerStats.instance.foundRunes[id])
			image.sprite = toggleSprites[0];
		else
			image.sprite = toggleSprites[1];

		if (clickedID != 0 && id == 0){
			image.color = Color.grey;
		}
		else if (available) {
			image.color = Color.white;
		}
		else if (clickedID == id){
			image.color = Color.blue;
		}
		else {
			image.color = Color.grey;
		}
	}

	public bool SetGoLocation(int clickedID, int nextID){
		LevelSpec spec = LevelSpec.instance;
Debug.Log("asdjasjdas  " + clickedID);
		spec.challangeTile = location.challangeTile;
		spec.width = location.width;
		spec.height = location.height;
		spec.pathPoints = location.pathPoints;
		spec.goalCount = location.goalCount;
		spec.enemyCount = location.enemyCount;
		if (PlayerStats.instance.foundRunes [clickedID]) {
			spec.goalCount = 0;
		}

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
		else if (id != PlayerStats.instance.currentLocation){
			image.color = Color.grey;
			return false;
		}
		else
			return false;
	}
}
