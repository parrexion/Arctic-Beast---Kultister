using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour {

	public Text daysText;
	public Text clearedText;

	
	void Update() {
		if (PlayerStats.instance == null)
			return;
		daysText.text = "Day " + PlayerStats.instance.days;
		int cleared = 0;
		for (int i = 0; i < PlayerStats.instance.foundRunes.Length; i++)
		{
			if (PlayerStats.instance.foundRunes[i])
			++cleared;
		}
		clearedText.text = cleared + " Runes";
	}
}
