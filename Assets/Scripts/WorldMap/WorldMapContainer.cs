using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapContainer : MonoBehaviour {

	#region Singleton
	public static WorldMapContainer instance = null;
	void Awake(){
		if (instance != null)
			Destroy(gameObject);
		else
			instance = this;
	}
	#endregion

	public Transform paths = null;
	public Transform locations = null;
}
