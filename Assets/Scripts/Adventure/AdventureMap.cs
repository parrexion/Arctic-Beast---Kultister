using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMap : MonoBehaviour {
	public int width = 20;
	public int height = 20;
	public int goalCount = 10;
	public int correctness = 5;
	public AdventureTile challangeTile;
	public AdventureTile walkableTile;
	public AdventureTile wallTile;
	public AdventureTile blockingWallTile;
	public AdventureTile[,] tiles;
	public PlayerActor player;
	public List<NPActor> npcs;
	private List<int[]> goalPoints = new List<int[]>();
	protected int maxx, maxy;
	// Use this for initialization
	void Start() {

		LevelSpec spec = LevelSpec.instance;

		if (spec != null) {

			challangeTile = spec.challangeTile;
			npcs = spec.npcs;
			correctness = spec.correctness;
			width = spec.width;
			height = spec.height;
			goalCount = spec.goalCount;

		}

		int[] startPoint = { 0, 0 };
		for(int i = 0; i < goalCount; ++i) {
			goalPoints.Add(new int[]{Random.Range(0, width), Random.Range(0, height)});
		}

		List<int[]> npcPoints = new List<int[]> ();
		foreach(NPActor ac in npcs) {
			ac.parentMap = this;
			npcPoints.Add(new int[]{ac.x, ac.y});

		}
		GlobalValues values = GlobalValues.instance;
		this.maxx = width;
		this.maxy = height;
		this.tiles = new AdventureTile[width, height];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++)
			{
				AdventureTile type = blockingWallTile;
				if (Random.Range (0, 2) == 1) type = wallTile;
				AddTile (i, j, type);
			}
		}

		//AddTile (startPoint [0], startPoint [1], walkableTile);

		//foreach (int[] gp in goalPoints) {
		//	AddTile (gp [0], gp [1], walkableTile);
		//
		//}

		List<int[]> walkables = new List<int[]> ();
		walkables.Add (startPoint);
		walkables.AddRange (goalPoints);
		walkables.AddRange (npcPoints);

		Shuffle (walkables);

		for (int i = 1; i < walkables.Count; ++i) {
			CreatePath (walkables[i-1], walkables[i], walkableTile);
		}

		CreatePath (new int[]{ width - 1, 0 }, new int[]{ 0, height - 1 }, challangeTile);

	}


	private int Sign(int i) {
		if (i == 0) return 0;
		Debug.Log ("Sign of " + i + " is " + (i / i));
		return i / Abs(i);
	}

	private int Abs(int i) {
		if (i == 0) return 0;
		return Mathf.Abs(i);
	}

	private void CreatePath(int[] start, int[] stop, AdventureTile type) {

		Debug.Log ("start: "+start[0]+", "+start[1]);
		Debug.Log ("stop: "+stop[0]+", "+stop[1]);
		int[] pos = start;
		int[] dir = { stop [0] - pos [0], stop [1] - pos [1] };
		AddTile (pos[0], pos[1], type);

		while(dir[1] != 0 || dir[0] != 0){
			Debug.Log (dir[0]+", "+dir[1]);

			int rand = Random.Range (0, 4);

			if (rand < 2) {
				Debug.Log ("Random nonsense on " + rand);
				pos [rand] = pos [rand] + Random.Range (-1, 2);
				if (pos [rand] < 0)
					pos [rand] = 0;
				if (pos [0] >= width)
					pos [0] = width - 1;
				if (pos [1] >= height)
					pos [0] = height - 1;
			}

			else {
				if (Abs (dir [0]) > Abs (dir [1])) {
					pos [0] = pos[0]+ Sign(dir[0]);
				}
				else {
					pos[1] = pos [1] + Sign(dir[1]);
				}
			}

			AddTile (pos[0], pos[1], type);

			dir = new[]{ stop [0] - pos [0], stop [1] - pos [1] };
		}

	}

	private void AddTile(int i, int j, AdventureTile type) {

		Debug.Log ("placing tiles at square "+i+", "+j);
		if (i>= width || j >= height)
			return;
		AdventureTile old = tiles [i, j];
		if (old != null) Destroy (old.gameObject);
		AdventureTile myTile = Instantiate(type, new Vector3(i, j, 0f), Quaternion.identity);
		myTile.initTile(i, j, this);
		this.tiles[i, j] = myTile;
	}

	private void Shuffle(List<int[]> list) {
		int n = list.Count;

		while (n > 1) {
			int k = Random.Range (0, n);
			n--;
			int[] val = list [k];
			list [k] = list [n];
			list [n] = val;
		}
	}

    public enum Direction {
        Zero,
        North,
        East,
        South,
        West
    }

    // Update is called once per frame
    void Update() {
        TurnManager turnManager = TurnManager.instance;
        if (!turnManager.isPlayerTurn)
        {
            Debug.Log("[NPC ACTIVITY]");
            foreach (NPActor npc in this.npcs)
            {
                //Debug.Log("npc acting");
                npc.act();
            }
            turnManager.isPlayerTurn = true;
        }
    }

    public AdventureTile getTileAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < this.maxx && y < this.maxy)
        {
            return this.tiles[x, y];
        }
        else
        {
            return null;
        }
    }

    public bool isTileOccupied(int x, int y, out NPActor outNpc)
    {
        outNpc = null;
        foreach (NPActor npc in this.npcs)
        {
            if (npc.x == x && npc.y == y) {
                outNpc = npc;
                return true;
            }
        }
        return false;
    }

    public static void stepFrom(ref int x, ref int y, AdventureMap.Direction dir)
    {
        switch (dir)
        {
            case Direction.North:
                y += 1;
                break;
            case Direction.South:
                y -= 1;
                break;
            case Direction.West:
                x -= 1;
                break;
            case Direction.East:
                x += 1;
                break;

        }
    }

    public static AdventureMap.Direction oppDirection(AdventureMap.Direction dir)
    {
        switch (dir)
        {
            case Direction.South: return Direction.North;
            case Direction.North: return Direction.South;
            case Direction.West: return Direction.East;
            case Direction.East: return Direction.West;
        }
        return Direction.North;
    }
    public static AdventureMap.Direction[] allDirections = new Direction[] {Direction.North,
        Direction.East, Direction.South, Direction.West };
}
