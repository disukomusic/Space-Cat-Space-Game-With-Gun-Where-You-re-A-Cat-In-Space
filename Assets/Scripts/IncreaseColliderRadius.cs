using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseColliderRadius : MonoBehaviour
{
    public SphereCollider collider;
    private void Awake()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseSizeOfCollider());
    }

    IEnumerator IncreaseSizeOfCollider()
    {
        for(int i = 0; i <10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            collider.radius += 1;
            yield return null;
        }
    }
}
