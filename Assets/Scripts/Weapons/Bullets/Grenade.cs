using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
public class Grenade : Bullet
{
    public override void Awake()
    {
        SoundManager.PlaySound(SoundManager.Sound.Grenade);
        base.Awake();
    }
    
    public override void OnCollisionEnter(Collision other)
    {
        //check if bullet hits environment or enemy
        if (other.gameObject.layer == 6 || other.gameObject.CompareTag("Enemy"))
        {
            ShakeScreen.Instance.ShakeCamera(5f,0.1f);
            Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }

    public override void OnEnemyHit()
    {
        ShakeScreen.Instance.ShakeCamera(5f,0.1f);
        Instantiate(hitEffect, transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}
