using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMap : MonoBehaviour {
	public int width = 4;
	public int height = 4;
	public int goalCount = 3;
	public List<AdventureTile> challangeTiles;
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

		int[] startPoint = { 0, 0 };
		for(int i = 0; i < goalCount; ++i) {
			goalPoints.Add(new int[]{Random.Range(0, width), Random.Range(0, height)});
		}
		GlobalValues values = GlobalValues.instance;
		this.maxx = width;
		this.maxy = height;
		this.tiles = new AdventureTile[maxx, maxy];
		for (int i = 0; i < maxx; i++) {
			for (int j = 0; j < maxy; j++)
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

		Shuffle (walkables);

		for (int i = 2; i < walkables.Count; ++i) {
			CreatePath (walkables[i-1], walkables[i], walkableTile);
		}

	}


	private int Sign(int i) {
		if (i == 0)
			return 0;
		else
			return i / i;
	}

	private void CreatePath(int[] start, int[] stop, AdventureTile type) {
		int[] pos = start;
		int[] dir = { stop [0] - pos [0], stop [1] - pos [1] };
		AddTile (start[0], start[1], type);

		while(dir[1] != 0 || dir[0] != 0){

			if (Mathf.Abs (dir [0]) > Mathf.Abs (dir [1])) {
				pos [0] = pos[0]+ Sign(dir[0]);
			}
			else {
				pos[1] = pos [1] + Sign(dir[1]);
			}
			dir = new[]{ stop [0] - pos [0], stop [1] - pos [1] };
		}

	}

	private void AddTile(int i, int j, AdventureTile type) {
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
