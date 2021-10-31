using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{    
    public enum PickupBehavior {Disable, Destroy, DoNothing}
    [Tooltip("What should happen to this object when picked up?")]
    [SerializeField] private PickupBehavior pickupBehavior = 0;

    public virtual void HandlePickup()
    {    
        switch (pickupBehavior) 
        {
            case PickupBehavior.Disable:
                this.gameObject.SetActive(false);
                break;
            case PickupBehavior.Destroy:
                Destroy(this.gameObject);
                break;
            case PickupBehavior.DoNothing:
                break;
            default:
                Debug.Log($"Pickup Behavior case not implemented in {this.gameObject.name}");
                break;        
        }
    }
}
