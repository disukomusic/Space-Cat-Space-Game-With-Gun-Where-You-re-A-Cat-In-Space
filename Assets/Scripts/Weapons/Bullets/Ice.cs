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
        SoundManager.PlaySound(SoundManager.Sound.Grenade);
    }
    
    public  void OnCollisionEnter(Collision other)
    {
        //check if bullet hits environment or player
        if (other.gameObject.layer == 6 || other.gameObject.CompareTag("Player"))
        {
            ShakeScreen.Instance.ShakeCamera(5f,0.1f);
            Player.Instance.DecreaseHealth(10f);
            Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}
