using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdventureMap : MonoBehaviour {

    public enum Direction {
        Zero,
        North,
        East,
        South,
        West
    }

    public AdventureTile[,] tiles;
    public PlayerActor player;
    public List<NPActor> npcs;
    public List<AdventureTile> prefabs;
    protected int maxx, maxy;
    // Use this for initialization
    void Start() {
        this.maxx = 4;
        this.maxy = 4;
        this.tiles = new AdventureTile[maxx, maxy];
        int n = prefabs.Count;
        for (int i = 0; i < maxx; i++) {
            for (int j = 0; j < maxy; j++)
            {
                AdventureTile myTile = Instantiate(prefabs[Random.Range(0, n)], new Vector3(i, j, 0f), Quaternion.identity);
                myTile.initTile(i, j, this);
                this.tiles[i, j] = myTile;
            }
        }
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