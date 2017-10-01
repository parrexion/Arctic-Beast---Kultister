using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldMap))]
public class MapPanelSetup : MonoBehaviour {

	#region Singleton
    public static MapPanelSetup instance = null;
    void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
			instance.gameObject.SetActive(true);
			instance.UpdateCurrentPosition();
		}
        else
            instance = this;
    }
    #endregion

	private WorldMap map;

	public Transform locationContainer = null;
	public Transform pathContainer = null;
	public Transform baseCamp = null;

	public GameObject LocationPrefab = null;
	public GameObject pathPrefab = null;

	public int screenWidth = 700;
	public int screenHeight = 450;

	public float mapHeight = 30;
	public float mapWidth = 30;

	[SerializeField]
	public List<LocationClick> locations = new List<LocationClick>();

	// Use this for initialization
	void Start () {
			GenerateMap();
			DontDestroyOnLoad(gameObject);
			Debug.Log("Generated map");
	}

	public void GenerateMap(){
		map = GetComponent<WorldMap>();
		map.ShufflePaths();
		RectTransform rect = GetComponent<RectTransform>();
		float branchesSize = (float)map.randomPaths.Length+1;
		float deviationRange = Mathf.PI / (branchesSize * 3);
		int id = 1;

		baseCamp.GetComponent<LocationClick>().id = 0;
		baseCamp.GetComponent<LocationClick>().backID = -1;
		baseCamp.GetComponent<LocationClick>().location.id = 0;
		baseCamp.GetComponent<LocationClick>().mapPanel = this;
		locations.Add(baseCamp.GetComponent<LocationClick>());

		for (int branch = 0; branch < map.randomPaths.Length; branch++) {
			Path p = map.randomPaths[branch];
			Location location = baseCamp.GetComponent<LocationClick>().location;
			Vector3 position = baseCamp.transform.position;

			mapWidth = screenWidth / (2*(p.locationsOnPath.Length)+1);
			mapHeight = screenHeight / (p.locationsOnPath.Length+1);

			for (int i = 0; i < p.locationsOnPath.Length; i++) {
				int cost = map.GetRandomTravelCost();
				Location nextLocation = p.locationsOnPath[i];
				nextLocation.travelCost = cost;

				GameObject createdLocation = GameObject.Instantiate(LocationPrefab);
				createdLocation.transform.SetParent(locationContainer);

				locations.Add(createdLocation.GetComponent<LocationClick>());
				locations[id].id = id;
				locations[id].location = nextLocation;
				locations[id].location.id = id;
				locations[id].backID = location.id;
				locations[id].mapPanel = this;
				id++;

				float angle = (branch+1)*Mathf.PI/branchesSize;
				angle += Random.Range(-deviationRange,deviationRange);
				createdLocation.transform.localPosition = 
							new Vector3((i+1) *mapWidth * Mathf.Cos(angle),
										(i+1) *mapHeight * Mathf.Sin(angle), 0);
				float distance = Vector3.Distance(position,createdLocation.transform.position) / 100f;
				Vector3 dir = createdLocation.transform.position - position;
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


	public void UpdateCurrentPosition(){
		for (int i = 0; i < locations.Count; i++) {
			locations[i].SetAvailable(PlayerStats.instance.currentLocation);
		}
	}

	public void ClickLocation(int id, int nextID){
		LevelSpec.instance.levelID = -1;
		LevelSpec.instance.nextLevelID = -1;
		for (int i = 0; i < locations.Count; i++) {
			locations[i].SetGoLocation(id, nextID);
		}
	}
	
}
