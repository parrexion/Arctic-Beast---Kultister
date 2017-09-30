using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(menuName = "World Map/Path")]
public class Path : ScriptableObject {
	public double travelRate = 0;
	public double terrainCost;
	public Location destination;

	public double travelCost() {
		double exp = 1 / (1 + travelRate);
		return terrainCost*(1-exp/2);
	}
}

