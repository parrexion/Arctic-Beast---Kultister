using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                AdventureTile myTile = Instantiate(prefabs[Random.Range(0, n)] , new Vector3((float) i, (float) j, 0f), Quaternion.identity );
                myTile.initTile(i, j, this);
                this.tiles.Add(new XYCoordinate(i, j), myTile);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class XYCoordinate
{
    protected int x;
    protected int y;
    public XYCoordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}