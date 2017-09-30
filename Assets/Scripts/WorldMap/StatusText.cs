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
		clearedText.text = PlayerStats.instance.cleared + " Areas";
	}
}
