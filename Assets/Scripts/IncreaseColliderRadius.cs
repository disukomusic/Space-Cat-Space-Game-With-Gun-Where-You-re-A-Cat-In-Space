using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class IncreaseColliderRadius : MonoBehaviour
{
    [SerializeField] private GameObject _collider;
    private void Awake()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseSizeOfCollider());
    }

    IEnumerator IncreaseSizeOfCollider()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _collider.transform.localScale += new Vector3(1f, 1f, 1f);
        }
    }
}
