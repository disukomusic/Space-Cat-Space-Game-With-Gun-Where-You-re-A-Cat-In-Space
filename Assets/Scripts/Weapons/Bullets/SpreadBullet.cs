using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpreadBullet : Bullet
{
    public override void Awake()
    {
        StartCoroutine(TEMPORARYBULLETTIMER_DONOTSHIP());
    }
}
