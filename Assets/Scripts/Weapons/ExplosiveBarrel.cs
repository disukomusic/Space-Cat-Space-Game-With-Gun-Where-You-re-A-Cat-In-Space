using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject explodeEffect;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            Debug.Log("Barrel Hit by Other Barrel");
            Explode();
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            Explode();
            Destroy(other.gameObject);
        }
    }

    public void Explode()
    {
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.Explode, transform.position);
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
