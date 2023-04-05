using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("enemy hit by bullet");
            Destroy(gameObject);
        }
        // for now, make it so collison by enemy reduces player health by some number
        // or should we make the enemies fire their own bullets and that decreases its health..?
        else if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("player hit by enemy");
        }
    }
}
