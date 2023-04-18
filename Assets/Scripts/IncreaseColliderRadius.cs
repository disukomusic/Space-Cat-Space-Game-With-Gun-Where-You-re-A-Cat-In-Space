using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseColliderRadius : MonoBehaviour
{
    public GameObject visual;
    private void Awake()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseSizeOfCollider());
    }

    IEnumerator IncreaseSizeOfCollider()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            visual.transform.localScale += new Vector3(1f,1f,1f);
        }
    }
}
