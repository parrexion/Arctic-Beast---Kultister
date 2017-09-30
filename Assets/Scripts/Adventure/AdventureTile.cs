using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TerrainType {
    Snow, //Basic terrain -- walkable by everyone
    Water, //Walkable by swimmers
    Rock, //Blocked, but doesn't block sight.
    BigRock, //Blocks walking, blocks sight.
    Tree,
};

[CreateAssetMenu (menuName = "Adventure Tile")]
public class AdventureTile : ScriptableObject {

    // Use this for initialization
    public Sprite graphic;
    //public string name;
    public bool blocksSight;
    public TerrainType terrainType;
    public List<GameItem> pickups;

    public OnEnterAction enterAction;
    public OnExitAction exitAction;
    public OnTickAction tickAction;

    public XYCoordinate coordinates;
    public AdventureMap parentMap;

    public void initTile(int x, int y, AdventureMap parentMap)
    {
        this.coordinates = new XYCoordinate(x, y);
        this.parentMap = parentMap;
    }

    bool TryWalk(Actor walker)
    {
        return walker.walkableTerrains.Contains(this.terrainType);
    }
    public void OnEnter() {
        this.enterAction.run();
    }
    public void OnExit()
    {
        this.enterAction.run();
}
    public void OnTick()
    {
        this.tickAction.run();
    }

}

public abstract class OnEnterAction
{
    public abstract void run();
}
public abstract class OnExitAction
{
    public abstract void run();
}
public abstract class OnTickAction
{
    public abstract void run();
}

