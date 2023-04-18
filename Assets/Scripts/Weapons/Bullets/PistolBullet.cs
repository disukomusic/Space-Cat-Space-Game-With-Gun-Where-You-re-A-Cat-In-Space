using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PistolBullet : Bullet
{
    public override void Awake()
    {
        SoundManager.PlaySound(SoundManager.Sound.PistolFire);
        base.Awake();
    }
}
