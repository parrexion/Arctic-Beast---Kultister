using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanelSetup : MonoBehaviour {

	public WorldMap map;

	public GameObject locationContainer;
	private Transform containerTransform;
	public GameObject locationPrefab;
	public float mapHeight = 45;
	public float mapWidth = 45;

	// Use this for initialization
	void Start () {
		containerTransform = locationContainer.GetComponent<Transform> ();
		List<Path> currentLevel = map.baseExits;
		List<Path> nextLevel = new List<Path>();
		List<List<Path>> levels = new List<List<Path>>();
		var locationsLeft = true;
		while (currentLevel.Count > 0) {
			foreach (Path p in currentLevel) {
				nextLevel.AddRange(p.destination.exits);

			}
			levels.Add(currentLevel);
			currentLevel = nextLevel;
			nextLevel = new List<Path>();
		}

		int level = 1;
		Debug.Log (levels.Count);
		foreach(List<Path> l in levels) {
			int location = 0;
			foreach (Path p in l) {
				Debug.Log (l.Count);
				Transform trans = GameObject
					.Instantiate(locationPrefab)
					.GetComponent<Transform>();

				trans.SetParent(containerTransform);
				trans.localPosition = new Vector3(location*(mapWidth/l.Count), level*(mapHeight/levels.Count), 0f);
				++location;
			}
			++level;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
