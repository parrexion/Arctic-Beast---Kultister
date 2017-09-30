using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{

    //protected <List>

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TurnManager turnManager = TurnManager.instance;
        AdventureMap.Direction wd = AdventureMap.Direction.Zero;
        if (!turnManager.isPlayerTurn)
        {
            return;
        }
        if (Input.GetKeyDown("up"))
        {
            wd = AdventureMap.Direction.North;
        }
        else if (Input.GetKeyDown("down"))
        {
            wd = AdventureMap.Direction.South;
        }
        else if (Input.GetKeyDown("right"))
        {
            wd = AdventureMap.Direction.East; 
        }
        else if (Input.GetKeyDown("left"))
        {
            wd = AdventureMap.Direction.West;
        }
        if (wd != AdventureMap.Direction.Zero)
        {
            NPActor npc;
            int ax = this.x;
            int ay = this.y;
            AdventureMap.stepFrom(ref ax, ref ay, wd);
            if ( this.parentMap.isTileOccupied(ax, ay, out npc))
            {
                turnManager.isPlayerTurn = !this.meleeAttack(wd);
            }
            else { 
                turnManager.isPlayerTurn = !this.walk(wd);
            }
        }
    }

    public override bool meleeAttack(AdventureMap.Direction ad)
    {
        int ax = this.x;
        int ay = this.y;
        NPActor npc;
        AdventureMap.stepFrom(ref ax, ref ay, ad);
        if (this.parentMap.isTileOccupied(ax, ay, out npc))
        {
            npc.takeDamage(this.attackStrength);
            return true;
        } else
        {
            return false;
        }
    }

}