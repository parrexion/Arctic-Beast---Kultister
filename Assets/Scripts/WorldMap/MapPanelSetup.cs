using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldMap))]
public class MapPanelSetup : MonoBehaviour {

	private WorldMap map;

	public Transform locationContainer = null;
	public Transform pathContainer = null;
	public Transform baseCamp = null;

	public GameObject LocationPrefab = null;
	public GameObject pathPrefab = null;

	public float mapHeight = 30;
	public float mapWidth = 30;

	// Use this for initialization
	void Start () {
		map = GetComponent<WorldMap>();
		map.ShufflePaths();
		RectTransform rect = GetComponent<RectTransform>();
		float branchesSize = (float)map.randomPaths.Length+1;
		float deviationRange = Mathf.PI / (branchesSize * 3);

		for (int branch = 0; branch < map.randomPaths.Length; branch++) {
			Path p = map.randomPaths[branch];
			Location location = baseCamp.GetComponent<LocationUI>().locationValues;
			Vector3 position = baseCamp.transform.position;

			mapWidth = rect.rect.width / 8f;
			mapHeight = rect.rect.height / (p.locationsOnPath.Length+1);

			for (int i = 0; i < p.locationsOnPath.Length; i++) {
				int cost = map.GetRandomTravelCost();
				Location nextLocation = p.locationsOnPath[i];
				nextLocation.travelCost = cost;

				GameObject createdLocation = GameObject.Instantiate(LocationPrefab);
				createdLocation.transform.SetParent(locationContainer);

				float angle = (branch+1)*Mathf.PI/branchesSize;
				angle += Random.Range(-deviationRange,deviationRange);
				createdLocation.transform.localPosition = 
							new Vector3((i+1) *mapWidth * Mathf.Cos(angle),
										(i+1) *mapHeight * Mathf.Sin(angle), 0);
				float distance = Vector3.Distance(position,createdLocation.transform.position) / 100f;
				Debug.Log("Distance: " + distance);
				Vector3 dir = createdLocation.transform.position - position;
				Debug.Log("dir: " + dir);
				angle = Mathf.Atan2(dir.y, dir.x) *Mathf.Rad2Deg;

				GameObject createdPaths = GameObject.Instantiate(pathPrefab);
				createdPaths.transform.SetParent(pathContainer);
				createdPaths.transform.position = position;
				createdPaths.transform.localScale = new Vector3(distance,1,1);

				createdPaths.transform.Rotate(new Vector3(0,0,angle));

				location.exits.Add(nextLocation);
				location = nextLocation;
				position = createdLocation.transform.position;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
