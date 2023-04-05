using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void Awake()
    {
        gameObject.tag = "Interactable";
    }

    public virtual void Interact()
    {
        // it doesn't get any more boilerplate than this!
        Debug.Log("we have interacted");
        Destroy(gameObject);
    }
}
