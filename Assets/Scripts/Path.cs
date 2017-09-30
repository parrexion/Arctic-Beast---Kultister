using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Path : ScriptableObject {
	public double travelRate = 0;
	public double terrainCost;
	public Location destination;
	public ArrayList<Path> exits;

	public double travelCost() {
		double exp = 1 / (1 + travelRate);
		return terrainCost*(1-exp/2);
	}
}

