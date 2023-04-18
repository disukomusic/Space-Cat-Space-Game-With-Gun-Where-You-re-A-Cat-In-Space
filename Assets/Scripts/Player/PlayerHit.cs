using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            StartCoroutine(WaterHurt());
        }
    }

    IEnumerator WaterHurt()
    {
        yield return new WaitForSeconds(0.5f);
        Player.Instance.HitPlayer(5f);
    }
}
