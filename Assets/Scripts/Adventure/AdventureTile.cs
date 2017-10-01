using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu (menuName = "Adventure Tile")]
public class AdventureTile : MonoBehaviour {

public enum TerrainType {
    Snow, //Basic terrain -- walkable by everyone
    Water, //Walkable by swimmers
    Rock, //Blocked, but doesn't block sight.
    BigRock, //Blocks walking, blocks sight.
    Tree,
};
    // Use this for initialization
    //public string name;
    public bool blocksSight;
    public TerrainType terrainType;
    public Item pickupItem;

    public OnEnterAction enterAction;
    public OnExitAction exitAction;
    public OnTickAction tickAction;

    public int x, y;
    public AdventureMap parentMap;

    public void initTile(int x, int y, AdventureMap parentMap)
    {
        this.x = x;
        this.y = y;
        this.parentMap = parentMap;
    }

    public bool CanWalk(Actor walker)
    {
        return walker.walkableTerrains.Contains(terrainType);
    }
    public void OnEnter(Actor actor) {
        this.enterAction.run(actor, this);
    }
    public void OnExit(Actor actor)
    {
        this.enterAction.run(actor, this);
}
    public void OnTick(Actor actor)
    {
        this.tickAction.run(actor, this);
    }

}
