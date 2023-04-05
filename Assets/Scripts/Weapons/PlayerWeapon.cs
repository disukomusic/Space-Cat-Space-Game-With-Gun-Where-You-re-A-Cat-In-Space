using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{    public Player player;

    private bool _canFire = true;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    public void Shoot(Bullet bullet)
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && _canFire && WeaponsManager.Instance.equippedWeapon)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        _canFire = false;
        Shoot(WeaponsManager.Instance.bullet);
        yield return new WaitForSeconds(WeaponsManager.Instance.fireRate);
        _canFire = true;
    }
    
}