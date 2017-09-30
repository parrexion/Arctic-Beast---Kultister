using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "World Map/Location")]

public class Location : ScriptableObject {

	[HideInInspector] public WorldMap map;
	[HideInInspector] public int id = -1;
	public string locationName;
	public float explorationRate = 0;
	public int travelCost = 10;
	[HideInInspector] public List<Location> exits;

}

