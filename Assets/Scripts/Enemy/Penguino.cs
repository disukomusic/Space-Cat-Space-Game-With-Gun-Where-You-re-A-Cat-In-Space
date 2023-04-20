using System;
using Unity.Mathematics;
using UnityEngine;


public class Penguino : MonoBehaviour
{
    [SerializeField] private GameObject icePrefab;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThrowIce();
        }
    }

    void ThrowIce()
    {
        GameObject ice = Instantiate(icePrefab, transform.position, Quaternion.identity);

        Vector3 throwDirection = transform.forward;
    
        Debug.DrawRay(transform.position, throwDirection * 5f, Color.blue, 2f);
        Vector3 upwardVector = Vector3.up * 1f; // Use world up direction instead of transform.up
        Vector3 forceVector = (throwDirection + upwardVector).normalized * 100f;
        ice.GetComponent<Rigidbody>().AddForce(forceVector, ForceMode.Impulse);
    }
}
