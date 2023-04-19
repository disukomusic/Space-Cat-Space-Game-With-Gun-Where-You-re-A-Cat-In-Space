using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : Destructable
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Explode();
            other.gameObject.GetComponent<Bullet>().OnEnemyHit();
        }
        base.OnTriggerEnter(other);
    }
}
