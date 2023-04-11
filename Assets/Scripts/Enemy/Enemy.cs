using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float damage;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Debug.Log("enemy hit by bullet");
            // set to false so the object pooler knows its available
            gameObject.SetActive(false);
        }
    }

    public void ResetSelf()
    {
        // sets gameObject to active and removes rigidbody velocity.
        // this is effectively a port of my 2D object pooler, resetting other 3D constraints may be necessary
        gameObject.SetActive(true);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
