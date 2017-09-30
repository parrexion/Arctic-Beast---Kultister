using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour {

	public int startExits = 3;
	public List<Path> paths;
	public List<int> pathCosts;
	public Path[] randomPaths;


	public void ShufflePaths(){
		randomPaths = new Path[paths.Count];
		int i = 0;
		while (paths.Count > 0) {
			int r = Random.Range(0,paths.Count);
			randomPaths[i] = paths[r];
			paths.RemoveAt(r);
			i++;
		}
	}


	public int GetRandomTravelCost(){
		int r = Random.Range(0,pathCosts.Count);
		int cost = pathCosts[r];
		pathCosts.RemoveAt(r);
		return cost;
	}
}
