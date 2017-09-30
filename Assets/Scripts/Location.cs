using System;
using UnityEngine;
using System.Collections;

public class Location : ScriptableObject {

	public string name;
	public double explorationRate = 0;

	public double encounterRisk() {
		return 1 - (1 / (1 + explorationRate));
	}
}

