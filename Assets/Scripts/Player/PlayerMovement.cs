using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Player _player;

    public float movementSpeed; 
    public float jumpForce;
    public bool grounded;

    void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _rigidbody.velocity = new Vector3(
            horizontal * movementSpeed * Time.deltaTime * 2, 
            _rigidbody.velocity.y, 
            vertical * movementSpeed * Time.deltaTime * 2);

    }
}