using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    private bool _touchingHurtZone;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DeathZone"))
        {
            _touchingHurtZone = true;
            StartCoroutine(DeathZoneHurt());
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("DeathZone"))
        {
            StopCoroutine(DeathZoneHurt());
            _touchingHurtZone = false;
        }
    }

    IEnumerator DeathZoneHurt()
    {
        while(_touchingHurtZone)
        {
            yield return new WaitForSeconds(0.5f);
            Player.Instance.HitPlayer(5f);
        }
    }
}
