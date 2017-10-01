using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enter Actions/Pick Up Rune")]

public class PickupRuneAction : OnEnterAction
{
    public override void run(Actor actor, AdventureTile tile)
    {
        if (!(actor is PlayerActor)) { return; }
        GameObject go = tile.gameObject;
        go.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = false;
        Item pui = tile.pickupItem;
        if (pui != null)
        {
            InventoryHandler.instance.SetRune(pui);
            Debug.Log("Picked up " + pui.itemName);
            tile.pickupItem = null;
        }
        tile.enterAction = new NullEnterAction ();
    }
}