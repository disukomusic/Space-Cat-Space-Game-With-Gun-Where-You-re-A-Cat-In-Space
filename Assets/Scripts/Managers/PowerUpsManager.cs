using System;
using System.Collections;
using UnityEngine;


public class PowerUpsManager : MonoBehaviour
{
    public static PowerUpsManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivatePowerUp(string itemName)
    {
        switch (itemName)
        {
            case "Rapid Fire":
                StartCoroutine(RapidFire());
                break;
            case "Barrel Hell":
                StartCoroutine(BarrelHell(20));
                break;
            case "Catnip":
                StartCoroutine(Speed());
                break;
        }
    }

    IEnumerator RapidFire()
    {
        float ogFireRate = WeaponsManager.Instance.fireRate;
        WeaponsManager.Instance.fireRate = 0.1f;
        yield return new WaitForSeconds(30f);
        WeaponsManager.Instance.fireRate = ogFireRate;
    }
    
    IEnumerator Speed()
    {
        float ogSpeed = Player.Instance.GetComponent<PlayerMovement>().movementSpeed;
        Player.Instance.GetComponent<PlayerMovement>().movementSpeed *= 1.5f;
        yield return new WaitForSeconds(30f);
        Player.Instance.GetComponent<PlayerMovement>().movementSpeed = ogSpeed;
    }

    IEnumerator BarrelHell(float barrelAmount)
    {
        for (int i = 0; i < barrelAmount; i++)
        {
            yield return null;
            GameManager.Instance.barrelSpawner.SpawnBarrelAtRandomPosition();
        }
    }
}
