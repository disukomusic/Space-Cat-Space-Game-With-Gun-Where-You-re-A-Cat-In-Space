using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.Initialize();
    }

    private void Start()
    {
        SoundManager.PlayMusic(SoundManager.Music.IdleMusic);

    }
}
