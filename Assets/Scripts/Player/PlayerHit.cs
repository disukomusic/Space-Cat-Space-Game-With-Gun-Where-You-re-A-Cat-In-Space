using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            float damage = other.gameObject.GetComponent<Enemy>().damage;
            Player.Instance.health -= damage;
            Player.Instance.DecreaseHealth(damage);
            
            SoundManager.PlaySoundAtPosition(SoundManager.Sound.PlayerHurt, transform.position);
            
            if (Player.Instance.health < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
