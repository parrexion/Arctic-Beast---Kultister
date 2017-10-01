using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : NPActor
{
    public AdventureMap.Direction patrolDirection;
    public override void act()
    {
        //Debug.Log("Patroller patrolling");
        foreach (AdventureMap.Direction ad in AdventureMap.allDirections)
        {
            if (this.meleeAttack(ad))
            {
               // Debug.Log("Patroller attacking");
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
    void Start()
    {
        int n = Random.Range(0, 4);
        this.patrolDirection = AdventureMap.allDirections[n];
    }
}