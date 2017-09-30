using UnityEngine;
using System.Collections;

public class Path : ScriptableObject {
	public double explorationRate = 0;
	public double terrainCost;

	public double travelCost() {
		double exp = 1 / (1 + explorationRate);
		return terrainCost*(1-exp/2);
	}
}

