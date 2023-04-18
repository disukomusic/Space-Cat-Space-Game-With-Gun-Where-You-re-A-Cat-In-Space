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
    public GameObject bullet;

    public void UnEquip(Item weapon)
    {
        AlertHandler.Instance.DisplayAlert("Unequipped weapon: " + equippedWeapon.name, Color.magenta);
        equippedWeapon = null;
        fireRate = 0;
        power = 0;
    }
    public void SetWeapon(Item weapon)
    {
        
        equippedWeapon = weapon;
        bullet = weapon.bullet;
        fireRate = weapon.value;
        power = weapon.value2;
        
        SetBulletData();
        
        AlertHandler.Instance.DisplayAlert("Equipped weapon: " + equippedWeapon.name, Color.magenta);
    }

    void SetBulletData()
    {
        bullet.GetComponent<Bullet>().fireRate = fireRate;
        bullet.GetComponent<Bullet>().power = power;
    }
}
