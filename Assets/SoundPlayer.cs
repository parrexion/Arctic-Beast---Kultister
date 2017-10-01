using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {


	#region Singleton
	public static SoundPlayer instance = null;
	void Awake(){
		if (instance != null)
			Destroy(gameObject);
		else
			instance = this;
	}
	#endregion

	// Use this for initialization
	public List<AudioClip> fieldSongs;
	public List<AudioClip> baseSongs;

	AudioSource source;
	void Start () {

		source = GetComponent<AudioSource> ();
		source.clip = fieldSongs [Random.Range (0, fieldSongs.Count)];
		source.Play ();
	}

	public void PlayField() {

		source.clip = fieldSongs [Random.Range (0, fieldSongs.Count)];
		source.Play ();

	}

	public void PlayBase() {

		source.clip = baseSongs [Random.Range (0, baseSongs.Count)];
		source.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
