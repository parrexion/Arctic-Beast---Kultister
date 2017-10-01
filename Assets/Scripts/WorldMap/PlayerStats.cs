using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	#region Singleton
	public static PlayerStats instance = null;
	void Awake(){
		if (instance != null)
			Destroy(gameObject);
		else {
			instance = this;
		}
	}
	#endregion

	public int currentHP;
	public int maxHP;

	public int days = 1;
	public int cleared = 0;
	public int currentLocation = 0;
}
