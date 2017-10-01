using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "World Map/Location")]

public class Location : ScriptableObject {

	[HideInInspector] public WorldMap map;
	[HideInInspector] public int id = -1;
	public AdventureTile challangeTile;
	public int width = 20;
	public int height = 20;
	public int pathPoints = 10;
	public int goalCount = 5;
	public int enemyCount = 5;
	public string locationName;
	public float explorationRate = 0;
	public int travelCost = 10;
	[HideInInspector] public List<Location> exits;

}

