using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enter Actions/Leave Zone")]

public class LeaveZone : OnEnterAction
{
    public override void run(Actor actor, AdventureTile tile)
    {
        if(!(actor is PlayerActor)) { return;  }
        TurnManager turnManager = TurnManager.instance;
        turnManager.isPaused = true;
        turnManager.ShowLeaveMenu();

    }
}