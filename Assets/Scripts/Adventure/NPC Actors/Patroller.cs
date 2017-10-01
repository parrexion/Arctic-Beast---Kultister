using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : NPActor
{
    public AdventureMap.Direction patrolDirection;
    public override void act()
    {
        Debug.Log("Patroller patrolling");
        foreach (AdventureMap.Direction ad in AdventureMap.allDirections)
        {
            if (this.meleeAttack(ad))
            {
                return;
            }
        }
        if (this.walk(this.patrolDirection))
        {
            //Debug.Log("Could walk in original direction.");
            this.startAnimation();
            return;
        } else
        {
            //Debug.Log("Changing direction.");
            this.patrolDirection = AdventureMap.oppDirection(this.patrolDirection);
            if (this.walk(this.patrolDirection)){
                this.startAnimation();
            }
        }
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
        else {
            return false;
        }
       
    }
}