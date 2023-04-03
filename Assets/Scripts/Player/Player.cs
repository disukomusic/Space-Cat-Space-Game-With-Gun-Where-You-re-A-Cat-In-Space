using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    
    public float score;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    public void ResetPlayerPosition()
    {
        _transform.position = new Vector3(0, 0f, 0f);
    }
}