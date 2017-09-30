using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldMap))]
public class MapPanelSetup : MonoBehaviour {

	private WorldMap map;

	public Transform locationContainer = null;
	public Transform baseCamp = null;
	public GameObject LocationPrefab = null;

	public float mapHeight = 90;
	public float mapWidth = 90;

	// Use this for initialization
	void Start () {
		map = GetComponent<WorldMap>();

		for (int branch = 0; branch < map.paths.Count; branch++) {
			Path p = map.paths[branch];
			Location location = baseCamp.GetComponent<LocationUI>().locationValues;
			for (int i = 0; i < p.locationsOnPath.Length; i++) {
				int cost = map.GetRandomTravelCost();
				Location nextLocation = p.locationsOnPath[i];
				nextLocation.travelCost = cost;
				location.exits.Add(nextLocation);
				location = nextLocation;

				GameObject createdLocation = GameObject.Instantiate(LocationPrefab);
				createdLocation.transform.SetParent(locationContainer);
				createdLocation.transform.position = 
							new Vector3((i+1) *mapWidth * Mathf.Cos((branch+1)*Mathf.PI/5f),
										(i+1) *mapHeight * Mathf.Sin((branch+1)*Mathf.PI/5f), 0);
				Debug.Log("Transfor: " + createdLocation.transform.position);
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
