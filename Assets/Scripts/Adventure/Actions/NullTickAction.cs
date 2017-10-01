using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tick Actions/Null Tick Action")]
public class NullTickAction : OnTickAction
{
    public override void run(Actor actor, AdventureTile tile)
    {
    }
}