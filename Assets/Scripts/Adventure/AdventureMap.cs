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
    public Dictionary<XYCoordinate, AdventureTile> tiles = new Dictionary<XYCoordinate, AdventureTile>();
    public PlayerActor player;
    public List<NPActor> npcs;
    public List<AdventureTile> prefabs;
    // Use this for initialization
    void Start() {
        int maxx = 4;
        int maxy = 4;
        this.tiles.Clear();
        int n = prefabs.Count;
        for (int i = 0; i < maxx; i++) {
            for (int j = 0; j < maxy; j++)
            {
                AdventureTile myTile = Instantiate(prefabs[Random.Range(0, n)], new Vector3(i, j, 0f), Quaternion.identity );
                myTile.initTile(i, j, this);
                this.tiles.Add(new XYCoordinate(i, j), myTile);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class XYCoordinate : IEqualityComparer<XYCoordinate>
{
    public int x;
    public int y;
    public XYCoordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Equals(XYCoordinate one, XYCoordinate other)
    {
        return other.x == one.x && one.y == other.y;    
    }
    public int GetHashCode(XYCoordinate coord)
    {
        return coord.x.GetHashCode() ^ coord.y.GetHashCode();
    }
}