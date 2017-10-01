using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class GoButtonScript : MonoBehaviour {

	private Button button;
	private LevelSpec levelSpec;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		levelSpec = LevelSpec.instance;
	}
	
	// Update is called once per frame
	void Update () {
		button.interactable = (levelSpec.levelID != -1);
	}

	public void GoButtonClick(){
		SceneManager.LoadScene(2);
	}
}
