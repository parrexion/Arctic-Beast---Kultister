using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Random;

public class RandomWalker : NPActor
{
    //public AdventureMap.Direction patrolDirection;

    private static System.Random rng = new System.Random();    

    public override void act()
    {
        Debug.Log("RandomWalker patrolling");
        foreach (AdventureMap.Direction ad in AdventureMap.allDirections)
        {
            if (this.meleeAttack(ad))
            {
                Debug.Log("RandomWalker attacking");
                return;
            }
        }
        AdventureMap.Direction[] dirs = AdventureMap.allDirections;
        var n = dirs.Length;
        for (var i = 0; i < n; i++) {
            var tmp = dirs[i];
            int j = rng.Next(i, n);
            dirs[i] = dirs[j];
            dirs[j] = tmp;
        }
        foreach (AdventureMap.Direction wd in dirs) {
            //Debug.Log("RandomWalker walking" + wd);
            if (this.walk(wd))
            {
                Debug.Log("RandomWalker walking" + wd);
                this.startAnimation();                
                return;
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