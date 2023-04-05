using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public static WeaponsManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public float power;
    public float fireRate;
    
    public Item equippedWeapon;
    public Bullet bullet;

    public void SetWeapon(Item weapon)
    {
        
        equippedWeapon = weapon;
        power = weapon.value;
        BalancePower();

        SetBulletData();
        
        Debug.Log("equipped weapon" + equippedWeapon.name);
    }

    private void BalancePower()
    {
        fireRate = (power - (power * 0.7f)) * 0.1f;
    }

    void SetBulletData()
    {
        bullet.fireRate = fireRate;
        bullet.power = power;
    }
}
