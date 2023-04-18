using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject explodeEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Explode();
            Destroy(other.gameObject);
        }else{ 
            if(other.CompareTag("Explosion"))
            {
                Explode();
                Destroy(other.gameObject);
            }
        }
    }

    public void Explode()
    {
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.Explode, transform.position);
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
