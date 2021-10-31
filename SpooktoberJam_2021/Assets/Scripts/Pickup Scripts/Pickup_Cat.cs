using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Cat : PickupItem
{

    private void Start()
    {
        //Add self to total cats count.
        GameManager.instance.AddToCatsTotal();
    }

    public override void HandlePickup()
    {
        GameManager.instance.AddToCatsRescued();
        UIManager.instance.UpdateCatCounter(0.0f);
        base.HandlePickup();        
    }
}
