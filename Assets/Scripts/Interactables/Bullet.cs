using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // this whole thing is just. a mess. consider an object pooler
    // or just toss this whole thing lol it doesn't work right
    private Rigidbody _rigidbody;
    public float bulletSpeed = 10f;
    public GameObject bullet;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
    }

    private void Update()
    {
        // just testing
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }
}
