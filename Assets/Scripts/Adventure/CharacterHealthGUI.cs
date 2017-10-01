using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterHealthGUI : MonoBehaviour {
    
	private enum Side {TOP,BOTTOM};

	private PlayerStats playerStats;

	public float bar_xpos = 0.04f;
	public float bar_ypos = 0.2f;
	public float bar_width = 0.1f;
	public float bar_height = 0.6f;
	public float bar_borderx = 0.05f;
	public float bar_bordery = 0.05f;

	[HideInInspector] public Rect healthRect;
	[HideInInspector] public Rect emptyRect;
	[HideInInspector] public Texture2D healthTexture;
	[HideInInspector] public Texture2D emptyTexture;
	
	// Use this for initialization
	void Start () {
		playerStats = PlayerStats.instance;

		healthRect = new Rect(Screen.width * bar_xpos, Screen.height * bar_ypos, Screen.width * bar_width, Screen.height * bar_height);
		emptyRect = new Rect(Screen.width*(bar_xpos-bar_borderx),Screen.height*(bar_ypos-bar_bordery),Screen.width*(bar_width+2*bar_borderx),Screen.height*(bar_height+2*bar_bordery));

        healthTexture = new Texture2D(1,1);
        healthTexture.SetPixel(0,0,Color.green);
        healthTexture.Apply();
        emptyTexture = new Texture2D(1,1);
        emptyTexture.SetPixel(0,0,Color.black);
        emptyTexture.Apply();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHealth();
	}

    void OnGUI() {
        GUI.DrawTexture(emptyRect,emptyTexture);
        GUI.DrawTexture(healthRect,healthTexture);
    }

    void UpdateHealth() {
		float ratio = 1f - (float)playerStats.currentHP / (float)playerStats.maxHP;

        healthTexture.SetPixel(0,0,Color.Lerp(Color.green,Color.red,ratio));
        healthTexture.Apply();
		healthRect.yMin = Screen.height * (ratio * bar_height + bar_ypos);
		healthRect.yMax = Screen.height * (bar_height + bar_ypos);

    }

}
