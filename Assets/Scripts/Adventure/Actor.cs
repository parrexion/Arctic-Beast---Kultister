using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
    public List<AdventureTile.TerrainType> walkableTerrains;
    // Use this for initialization

    public int x, y;
    public int hp;
    public int attackStrength;
    public AdventureMap parentMap;
    protected int goalx, goaly;
    protected bool animating = false;
    protected float animationTimer = 0f;
    public float animationLength = 0.3f;
    protected Vector3 animStart, animEnd;

    public GameObject effectsRenderer;

    public void initPlayer(int x, int y, AdventureMap parentMap)
    {
        this.x = x;
        this.y = y;
        this.parentMap = parentMap;
    }

    protected void startAnimation()
    {
        this.animating = true;
        this.animStart = transform.position;
        this.animEnd = new Vector3(this.x, this.y, 0f);
       // Debug.Log("Starting animation to " + this.animEnd);
    }

    protected virtual void stopAnimation()
    {
        this.animating = false;
        this.animationTimer = 0;
        TurnManager turnManager = TurnManager.instance;
        turnManager.passPlayerTurn();
    }

    protected void animate()
    {
        if (!this.animating ) { return; }
        animationTimer += Time.deltaTime;
        //Debug.Log("Animating: " + animationTimer);
        transform.position = Vector3.Lerp(this.animStart, this.animEnd, animationTimer/animationLength);
        if (animationTimer >= animationLength)
        {
            this.stopAnimation();
        }
    }

    public virtual bool meleeAttack(AdventureMap.Direction ad)
    {
        return false;
    }

    public virtual void takeDamage(int dmg)
    {
        this.hp -= dmg;
        Debug.Log(string.Format("Took {0} damage. HP now {1}", dmg, this.hp));
        this.renderEffect();
        if(this.hp <= 0)
        {
            this.die();
        }
    }
    public virtual void die()
    {
        return;
    }

    public void renderEffect()
    {
        if (this.effectsRenderer != null)
        {
            GameObject eff = Instantiate(this.effectsRenderer, new Vector3(0f, 0f, 0f), Quaternion.identity);
            eff.transform.position = transform.position;
            Destroy(eff, 0.3f);
        }
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
                //transform.position = new Vector3(x, y, 0f);
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