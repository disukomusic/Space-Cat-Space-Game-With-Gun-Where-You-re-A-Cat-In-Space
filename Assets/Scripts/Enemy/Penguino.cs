using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Penguino : MonoBehaviour
{
    [SerializeField] private GameObject icePrefab;
    private bool throwing;
    public float WaitTime;
    float timer;


    private void Update()
    {
        timer += Time.deltaTime;
        
        throwing = Vector3.Distance(transform.position, Player.Instance.transform.position) < 50f;

        if (timer >= Random.Range(0.75f, 1f) && throwing)
        {
            GameObject ice = Instantiate(icePrefab, transform.position, Quaternion.identity);

            Vector3 throwDirection = (Player.Instance.transform.position - transform.position).normalized;
            Vector3 upwardVector = Vector3.up * 0.1f; // Use world up direction instead of transform.up
            Vector3 forceVector = (throwDirection + upwardVector).normalized;
            ice.GetComponent<Rigidbody>().AddForce(forceVector * 50f, ForceMode.Impulse); 
            timer = 0f;
        }
        
    }

    // private void Awake()
    // {
    //     StartCoroutine(ThrowIce());
    // }

    //
    // IEnumerator ThrowIce()
    // {
    //     while(true)
    //     {
    //         if (throwing)
    //         {
    //             yield return new WaitForSeconds(Random.Range(0.75f, 1f));
    //
    //             SoundManager.PlaySoundAtPosition(SoundManager.Sound.IceThrow, transform.position);
    //             GameObject ice = Instantiate(icePrefab, transform.position, Quaternion.identity);
    //
    //             Vector3 throwDirection = (Player.Instance.transform.position - transform.position).normalized;
    //             Vector3 upwardVector = Vector3.up * 0.1f; // Use world up direction instead of transform.up
    //             Vector3 forceVector = (throwDirection + upwardVector).normalized;
    //             ice.GetComponent<Rigidbody>().AddForce(forceVector * 50f, ForceMode.Impulse); 
    //         }
    //         else
    //         {
    //             yield return null;
    //         }
    //     }
    // }
}
