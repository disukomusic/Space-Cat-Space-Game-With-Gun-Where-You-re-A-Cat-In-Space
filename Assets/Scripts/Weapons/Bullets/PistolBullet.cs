using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PistolBullet : Bullet
{
    public override void Awake()
    {
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.PistolFire, transform.position);
        base.Awake();
    }
}
