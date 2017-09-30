using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour {

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
