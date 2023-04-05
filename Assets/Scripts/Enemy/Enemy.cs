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
    }
}
