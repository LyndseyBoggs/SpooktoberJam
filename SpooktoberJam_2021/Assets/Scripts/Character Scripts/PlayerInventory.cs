/////////////////////////////////////////////////////////////////////////////////
/// 
/// Inventory of references to the objects (ie: cats) the player has picked up.
/// 
/// Lyndsey Boggs
/// 10/30/2021 [Spooktober Game Jam]
/////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventory;

    //As the player collides with an object trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the object is an inventory item
        if (collision.gameObject.GetComponent<PickupItem>())
        {
            PickupItem(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the object is an inventory item
        if (collision.gameObject.GetComponent<PickupItem>())
        {
            PickupItem(collision.gameObject);
        }
    }

    private void PickupItem(GameObject pickup)
    {
        //add to inventory
        inventory.Add(pickup);
        //handle pickup behavior
        pickup.gameObject.GetComponent<PickupItem>().HandlePickup();
    }
}
