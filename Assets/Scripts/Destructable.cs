using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{    
    public GameObject destroyEffect;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            Explode();
        }

    }

    public void Explode()
    {
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.Explode, transform.position);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
