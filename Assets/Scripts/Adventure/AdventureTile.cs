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

public abstract class AdventureTile : ScriptableObject {

    // Use this for initialization
    public Sprite graphic;
    //public string name;
    public bool blocksSight;
    public TerrainType terrainType;
    public List<GameItem> pickups;

    bool TryWalk(Actor walker)
    {
        return walker.walkableTerrains.Contains(this.terrainType);
    }
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnTick();

}
