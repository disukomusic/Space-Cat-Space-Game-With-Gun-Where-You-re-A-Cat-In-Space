using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stolen from https://www.youtube.com/watch?v=QL29aTa7J5Q
/// </summary>
public class GameAssets : MonoBehaviour
{

    public static GameAssets Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public SoundAudioClip[] SoundAudioClips;
    [System.Serializable] public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip AudioClip;
    }

    public MusicAudioClip[] MusicAudioClips;

    [System.Serializable] public class MusicAudioClip
    {
        public SoundManager.Music music;
        public AudioClip AudioClip;
    }
}
