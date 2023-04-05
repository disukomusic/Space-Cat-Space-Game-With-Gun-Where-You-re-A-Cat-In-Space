using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Interactable interactable = col.GetComponent<Interactable>();
        
        // may want to delve into layer masks if we have other items moving through each other,
        // or to react differently if an enemy picks one up
        interactable.Interact();
    }

}
