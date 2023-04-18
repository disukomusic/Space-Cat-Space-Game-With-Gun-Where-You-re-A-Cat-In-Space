using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// Stolen from https://www.youtube.com/watch?v=QL29aTa7J5Q
/// </summary>

public class SoundManager : MonoBehaviour
{
    public enum Sound
    {
        CatJazz,
        
        PlayerStep,
        PlayerHurt,
        PlayerDie,
        
        PistolFire,
        ShotgunFire,
        
        
        EnemySpawn,
        EnemyHurt,
        EnemyDie,
        
        UIHover,
        UIClick,
        
        ItemSpawn,
        ItemPickup,
        ItemUse,
        ItemToss,
    }

    public enum Music
    {
        CatJazz,
        FightMusic,
        IdleMusic,
    }
    private static Dictionary<Sound, float> _soundTimerDictionary;
    
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    private static GameObject musicGameObject;
    private static AudioSource musicAudioSource;
    public static void Initialize()
    {
        _soundTimerDictionary = new Dictionary<Sound, float>
        {
            [Sound.EnemyDie] = 0
        };
    }

    public static void PlayMusic(Music music)
    {
        if (musicGameObject == null)
        {
            musicGameObject = new GameObject("Music");
            musicAudioSource = musicGameObject.AddComponent<AudioSource>();
        }
        musicAudioSource.Stop();
        musicAudioSource.clip = GetMusicClip(music);
        musicAudioSource.Play();
    }
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }
            oneShotAudioSource.volume = 0.5f;
            oneShotAudioSource.PlayOneShot(GetSoundClip(sound));
        }
    }
    public static void PlaySoundAtPosition(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {

            GameObject soundGameObject = new GameObject("One Shot Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            
            soundGameObject.transform.position = position;

            audioSource.volume = 0.5f;
            audioSource.maxDistance = 100f;
            audioSource.pitch += Random.Range(-0.2f, 0.2f);
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.spatialBlend = 1f;
            
            audioSource.clip = GetSoundClip(sound);
            audioSource.Play();

            Destroy(soundGameObject, audioSource.clip.length);
;        }
    }
    
    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.PlayerStep:
                if (_soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = _soundTimerDictionary[sound];
                    float playerStepTimerMax = 0.5f;
                    if (lastTimePlayed + playerStepTimerMax < Time.time)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                //break;
        }
    }

    private static AudioClip GetSoundClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.Instance.SoundAudioClips)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.AudioClip;
            }
        }
        Debug.LogError("Sound " + sound + "not found! (Skill issue, L, Ratio)");
        return null;
    }
    
    private static AudioClip GetMusicClip(Music music)
    {
        foreach (GameAssets.MusicAudioClip musicAudioClip in GameAssets.Instance.MusicAudioClips)
        {
            if (musicAudioClip.music == music)
            {
                return musicAudioClip.AudioClip;
            }
        }
        Debug.LogError("Music " + music + "not found! (Skill issue, L, Ratio)");
        return null;
    }

}
