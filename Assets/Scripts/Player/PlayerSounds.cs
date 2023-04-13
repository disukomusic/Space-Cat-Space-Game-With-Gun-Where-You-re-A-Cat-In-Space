using System;
using UnityEngine;


public class PlayerSounds : MonoBehaviour
{
    public AudioClip catjazz;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void playSound(string name)
    {
        _audioSource.Stop();
        AudioClip clip = null;

        switch (name)
        {
            case "catjazz":
                clip = catjazz;
                break;
            default:
                Debug.LogWarning("No AudioClip found for name " + name);
                break;
        }
        
        _audioSource.PlayOneShot(clip);
    }
}
