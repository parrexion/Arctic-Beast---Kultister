using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPActor : Actor {

    public abstract void act();

    protected override void stopAnimation()
    {
        this.animating = false;
        this.animationTimer = 0;
        //TurnManager turnManager = TurnManager.instance;
        //turnManager.passNPCTurn();
    }

    public override void die()
    {
        Debug.Log("NPC dying.");
        this.parentMap.npcs.RemoveAll(n => n.x == this.x && n.y == this.y);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.animate();

    }
    public override bool meleeAttack(AdventureMap.Direction ad)
    {
        PlayerActor pc = this.parentMap.player;
        int ax = this.x;
        int ay = this.y;
        AdventureMap.stepFrom(ref ax, ref ay, ad);
        if (pc.x == ax && pc.y == ay)
        {
            pc.takeDamage(this.attackStrength);
            return true;
        }
        else
        {
            return false;
        }
    }
}
