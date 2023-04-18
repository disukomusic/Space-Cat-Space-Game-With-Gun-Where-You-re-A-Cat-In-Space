using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private DetectMouseOver uiMouseOver;

    private bool _canFire = true;

    public void Shoot(GameObject bullet)
    {
        Instantiate(bullet, transform.position + new Vector3(0f,2f,0f), transform.rotation);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _canFire && WeaponsManager.Instance.equippedWeapon && !uiMouseOver.mouseOver)
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
