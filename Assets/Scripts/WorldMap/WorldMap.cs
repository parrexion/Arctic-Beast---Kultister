using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour {

	public int startExits = 3;
	public List<Path> paths;
	public List<int> pathCosts;


	public int GetRandomTravelCost(){
		int r = Random.Range(0,pathCosts.Count);
		int cost = pathCosts[r];
		pathCosts.RemoveAt(r);
		return cost;
	}
}
