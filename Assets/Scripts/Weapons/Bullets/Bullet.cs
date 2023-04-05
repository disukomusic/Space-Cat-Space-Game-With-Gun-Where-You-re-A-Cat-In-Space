using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power;
    public float fireRate;
    public float speed = 10f;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //this is jank as hell and barely works
        //ask hunter or bill about it because im losing it its too late for this
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector3 cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition ).direction;
        Vector3 flatAimTarget = screenPoint  + cursorRay  / Mathf.Abs( cursorRay.y ) * Mathf.Abs( screenPoint .y - Player.Instance.transform.position.y );
        _rigidbody.AddRelativeForce(flatAimTarget);
    }
}
