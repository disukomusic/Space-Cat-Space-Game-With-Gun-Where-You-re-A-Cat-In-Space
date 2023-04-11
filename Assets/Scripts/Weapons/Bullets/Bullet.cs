﻿using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power;
    public float fireRate;
    public float speed = 1000f;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        StartCoroutine(TEMPORARYBULLETTIMERDELETEME());
        _rigidbody = GetComponent<Rigidbody>();
       
        //we can either add some height offset to the aim target or we can flatten the direction after to make it ... flat
        Vector3 flatAimTarget = Hunter.Utility.GetMousePositionOnGroundPlane() - transform.position;
        flatAimTarget = new Vector3(flatAimTarget.x, 0, flatAimTarget.z).normalized;
        
        transform.rotation = Quaternion.LookRotation(flatAimTarget);
        _rigidbody.AddForce(flatAimTarget * speed);
    }


    IEnumerator TEMPORARYBULLETTIMERDELETEME()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
