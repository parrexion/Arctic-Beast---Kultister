using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GiveupButtonScript : MonoBehaviour {

	private Button button;
	private PlayerStats playerStats;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		playerStats = PlayerStats.instance;
	}
	
	// Update is called once per frame
	void Update () {
		button.interactable = (playerStats.currentLocation != 0);
	}

	public void GiveupButtonClick(){
		playerStats.currentLocation = 0;
	}
}
