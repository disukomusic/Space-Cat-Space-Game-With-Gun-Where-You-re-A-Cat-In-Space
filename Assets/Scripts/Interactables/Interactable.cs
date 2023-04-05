using System.Collections;
using System.Collections.Generic;using System.IO.Enumeration;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        // it doesn't get any more boilerplate than this!
        Debug.Log("we have interacted");
        Destroy(gameObject);
    }
}
