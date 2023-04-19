using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [Range(0,1)]
    public float t; // T because lerp

    // currently using Transforms but it may be in your interest to use Vector3s
    public int sign = 1;
    public Transform A;
    public Transform B;

    // public Material matA;
    // public Material matB;

    private MeshRenderer _meshRenderer;

    // think vegas keyframes
    public AnimationCurve ease;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        sign = 1;
        t = 0;
    }

    private void Update()
    {
        // this setup should make it loop back and forth
        t = t + sign * Time.deltaTime;
        
        if (t > 1)
        {
            sign = -1;
        }
        else if (t < 0)
        {
            sign = 1;
        }

        // set our position = LERP between a,b controlled by t
        transform.position = Vector3.Lerp(A.position, B.position, ease.Evaluate(t));
        // _meshRenderer.material.Lerp(matA,matB,ease.Evaluate(t));
    }
}
