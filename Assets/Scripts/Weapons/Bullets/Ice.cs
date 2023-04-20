using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
public class Ice : MonoBehaviour
{
    public GameObject hitEffect;
    public void Awake()
    {
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.IceThrow, transform.position);
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySoundAtPosition(SoundManager.Sound.IceBreak, transform.position);
            ShakeScreen.Instance.ShakeCamera(5f,0.1f);
            Player.Instance.HitPlayer(2f);
            Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
        //check if bullet hits environment
        else if (other.gameObject.layer == 6)
        {
            SoundManager.PlaySoundAtPosition(SoundManager.Sound.IceBreak, transform.position);
            Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(gameObject); 
        }
    }
}
