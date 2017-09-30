using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour {

	public List<AdventureTile> defeatableTiles;
	public AdventureTile walkableTile;
	public AdventureTile wall;
	public AdventureTile blockingWall;

	#region Singleton
	public static GlobalValues instance = null;
	void Awake(){
		if (instance != null)
			Destroy(gameObject);
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	#endregion
	
}
