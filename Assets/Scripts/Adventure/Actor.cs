using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
    public List<TerrainType> walkableTerrains ;
    // Use this for initialization

    public XYCoordinate coordinates;
    public AdventureMap parentMap;

    public void initPlayer(int x, int y, AdventureMap parentMap)
    {
        this.coordinates = new XYCoordinate(x, y);
        this.parentMap = parentMap;
    }

    public bool walk(Direction wd)
    {
        int x = this.coordinates.x;
        int y = this.coordinates.y;
        switch (wd)
        {
            case Direction.North:
                y += 1;
                break;
            case Direction.South:
                y -= 1;
                break;
            case Direction.West: x -= 1;
                break;
            case Direction.East: x += 1;
                break;

        }
        Debug.Log(string.Format("Trying to walk. {0} {1} {2}", this.parentMap.tiles.Count, x, y));
        foreach( XYCoordinate k in this.parentMap.tiles.Keys)
        {
            Debug.Log(string.Format("{0} {1}", k.x, k.y));
        }
        AdventureTile targetTile;
        XYCoordinate targetCoords = new XYCoordinate(x, y);
        if (this.parentMap.tiles.TryGetValue(targetCoords, out targetTile))
        {
            if (targetTile.CanWalk(this))
            {
                Debug.Log("Can enter tile");
                this.coordinates = targetCoords;
                transform.position = new Vector3(x, y, 0f);
                targetTile.OnEnter();
                return true;
            }
            else
            {
                Debug.Log("Cannot enter tile");
                return false;
            }
        }
        else
        {
			Debug.Log ("Could not find tile at {0} {1}.");
            return false;
        }
            
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}