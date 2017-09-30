using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "World Map/Map")]
public class WorldMap : ScriptableObject {
	public List<Path> paths;
	public List<Location> locations;
	public List<Path> baseExits;

}
