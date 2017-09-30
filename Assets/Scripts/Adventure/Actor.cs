using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
    public List<AdventureTile.TerrainType> walkableTerrains ;
    // Use this for initialization

    public int x, y;
    public AdventureMap parentMap;

    public void initPlayer(int x, int y, AdventureMap parentMap)
    {
        this.x = x;
        this.y = y;
        this.parentMap = parentMap;
    }

    public bool walk(AdventureMap.Direction wd)
    {
        int x = this.x;
        int y = this.y;
        switch (wd)
        {
            case AdventureMap.Direction.North:
                y += 1;
                break;
            case AdventureMap.Direction.South:
                y -= 1;
                break;
            case AdventureMap.Direction.West: x -= 1;
                break;
            case AdventureMap.Direction.East: x += 1;
                break;

        }
        //Debug.Log(string.Format("Trying to walk. {0} {1} {2}", this.parentMap.tiles.Count, x, y));
        AdventureTile targetTile = this.parentMap.getTileAt(x, y);
        if (targetTile != null)
        {
            if (targetTile.CanWalk(this))
            {
                Debug.Log("Can enter tile");
                this.x = x;
                this.y = y;
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