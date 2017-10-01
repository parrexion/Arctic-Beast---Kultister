using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
    public List<AdventureTile.TerrainType> walkableTerrains ;
    // Use this for initialization

    public int x, y;
    public int hp;
    public int attackStrength;
    public AdventureMap parentMap;

    public void initPlayer(int x, int y, AdventureMap parentMap)
    {
        this.x = x;
        this.y = y;
        this.parentMap = parentMap;
    }

    public virtual bool meleeAttack(AdventureMap.Direction ad)
    {
        return false;
    }

    public virtual void takeDamage(int dmg)
    {
        this.hp -= dmg;
        Debug.Log(string.Format("Took {0} damage. HP now {1}", dmg, this.hp));
        if(this.hp <= 0)
        {
            this.die();
        }
    }
    public virtual void die()
    {
        return;
    }

    public bool walk(AdventureMap.Direction wd)
    {
        int x = this.x;
        int y = this.y;
        AdventureMap.stepFrom(ref x, ref y, wd);
        //Debug.Log(string.Format("Trying to walk. {0} {1} {2}", this.parentMap.tiles.Count, x, y));
        AdventureTile targetTile = this.parentMap.getTileAt(x, y);
        AdventureTile sourceTile = this.parentMap.getTileAt(this.x, this.y);
        if (targetTile != null)
        {
            if (targetTile.CanWalk(this))
            {
                this.x = x;
                this.y = y;
                transform.position = new Vector3(x, y, 0f);
                sourceTile.OnExit(this);
                targetTile.OnEnter(this);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
            
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}