using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationUI : MonoBehaviour {

	public Location locationValues;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickLocation(){
		Debug.Log("You clicked location " + locationValues.name);
	}
}
