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
	public int width = 4;
	public int height = 4;
	public int goalCount = 3;
	public int correctness = 4;
	public AdventureTile challangeTile;
	public List<NPActor> npcs;
}
