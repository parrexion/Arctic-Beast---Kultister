using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpec : MonoBehaviour {

	public int width = 4;
	public int height = 4;
	public int goalCount = 3;
	public int correctness = 4;
	public AdventureTile challangeTile;
	public List<NPActor> npcs;
}
