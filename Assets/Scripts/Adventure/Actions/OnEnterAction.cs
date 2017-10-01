using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnEnterAction : ScriptableObject
{
    public abstract void run(Actor actor, AdventureTile tile);
}