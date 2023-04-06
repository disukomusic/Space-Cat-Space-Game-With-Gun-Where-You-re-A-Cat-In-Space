using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public TMP_Text healthText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            float damage = other.gameObject.GetComponent<Enemy>().damage;
            Player.Instance.health -= damage;
            Player.Instance.DecreaseHealth(damage);
            
        }
    }
}
