using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FreezeThenShatter : MonoBehaviour
{
    public GameObject ShatterPrefab;
    private void Awake()
    {
        StartCoroutine(FreezeShatter());
    }

    private IEnumerator FreezeShatter()
    {
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.Freeze,transform.position);
        
        yield return new WaitForSeconds(1f);
        
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.IceBreak,transform.position);
        Instantiate(ShatterPrefab, transform.position, transform.localRotation);
        Destroy(transform.parent.gameObject);
    }
}
