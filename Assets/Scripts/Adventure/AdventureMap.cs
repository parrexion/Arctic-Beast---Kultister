using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    North,
    East,
    South,
    West
}

public class AdventureMap : MonoBehaviour {
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
}