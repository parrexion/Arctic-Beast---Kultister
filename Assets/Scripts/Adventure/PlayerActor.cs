using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{

    protected int hp;

    //protected <List>

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Walking north");
            this.walk(Direction.North);
        }
        else if (Input.GetKeyDown("down"))
        {
            this.walk(Direction.South);
        }
        else if (Input.GetKeyDown("right"))
        {
            this.walk(Direction.East);
        }
        else if (Input.GetKeyDown("left"))
        {
            this.walk(Direction.West);
        }
    }
}