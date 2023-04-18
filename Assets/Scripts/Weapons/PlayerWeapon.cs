using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{   
    [HideInInspector] public Player player;

    private bool _canFire = true;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    public void Shoot(GameObject bullet)
    {
        Instantiate(bullet, transform.position + new Vector3(0f,1f,0f), transform.rotation);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _canFire && WeaponsManager.Instance.equippedWeapon)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        _canFire = false;
        Shoot(WeaponsManager.Instance.equippedWeapon.bullet);
        yield return new WaitForSeconds(WeaponsManager.Instance.fireRate);
        _canFire = true;
    }
    
}
