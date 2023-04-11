using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float baseHealth;
    public TMP_Text healthText;

    private float _health;
    private Rigidbody _rigidbody;
    private Transform mainCameraTransform;



    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        ResetSelf();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _health -= WeaponsManager.Instance.power;
            healthText.text = _health.ToString();
            
            Destroy(other.gameObject);
            Debug.Log("enemy hit by bullet");
            // set to false so the object pooler knows its available

            if (_health < 1)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetSelf()
    {
        _health = baseHealth;
        healthText.text = _health.ToString();
        // sets gameObject to active and removes rigidbody velocity.
        // this is effectively a port of my 2D object pooler, resetting other 3D constraints may be necessary
        gameObject.SetActive(true);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
    
}
