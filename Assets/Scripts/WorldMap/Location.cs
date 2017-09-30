using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "World Map/Location")]
public class Location : ScriptableObject {

	public string locationName;
	public double explorationRate = 0;
	public List<Path> exits;

	public double encounterRisk() {
		
		return 1 - (1 / (1 + explorationRate));
	}
}

