using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class MyPeopleNeedMe : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 2000f);
        
        GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-60f,60f), Random.Range(-360f,360f), Random.Range(-60f,60f)));

        Destroy(gameObject, 3f);
    }
}
