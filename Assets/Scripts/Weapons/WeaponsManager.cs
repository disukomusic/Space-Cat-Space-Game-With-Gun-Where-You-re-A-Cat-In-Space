using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        fireRate = weapon.value;
        
        power = RemapFireRateToPower(fireRate);

        SetBulletData();
        
        AlertHandler.Instance.DisplayAlert("Equipped weapon: " + equippedWeapon.name, Color.magenta);
    }
    
    float RemapFireRateToPower(float weaponFireRate)
    {
        float normalizedFireRate = 1.0f - weaponFireRate;
        
        float remappedPower = Mathf.Lerp(10, 0, normalizedFireRate);
        
        return remappedPower;
    }

    void SetBulletData()
    {
        bullet.fireRate = fireRate;
        bullet.power = power;
    }
}
