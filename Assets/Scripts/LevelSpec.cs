using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpec : MonoBehaviour {

	#region Singleton
	public static LevelSpec instance = null;
	void Awake(){
		if (instance != null)
			Destroy(gameObject);
		else
			instance = this;
	}
	#endregion

	public int levelID = -1;
	public int nextLevelID = -1;
	public int width = 20;
	public int height = 20;
	public int goalCount = 10;
	public int correctness = 5;
	public AdventureTile challangeTile;
	public List<NPActor> npcs;
}
