using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "World Map/Location")]
public class Location : ScriptableObject {

	private WorldMap map;
	public string locationName;
	public float explorationRate = 0;
	public int travelCost = 10;
	[HideInInspector] public List<Location> exits;


	public float encounterRisk() {
		
		return 1f - (1f / (1f + explorationRate));
	}

}

