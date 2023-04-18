using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power;
    public float fireRate;
    public float speed = 10f;

    private Rigidbody _rigidbody;

    public virtual void Awake()
    {
        StartCoroutine(TEMPORARYBULLETTIMER_DONOTSHIP());
        _rigidbody = GetComponent<Rigidbody>();
       
        //we can either add some height offset to the aim target or we can flatten the direction after to make it ... flat
        Vector3 flatAimTarget = Hunter.Utility.GetMousePositionOnGroundPlane() - transform.position;
        flatAimTarget = new Vector3(flatAimTarget.x, 0.5f, flatAimTarget.z).normalized;
        
        transform.rotation = Quaternion.LookRotation(flatAimTarget);
        _rigidbody.AddForce(flatAimTarget * speed);
    }

    protected IEnumerator TEMPORARYBULLETTIMER_DONOTSHIP()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        //check if bullet hits environment
        if (other.gameObject.layer == 6)
        {
            Debug.Log("bullet hit environment");
            //instantiate juice prefab, bullet hit particles?
            Destroy(gameObject);
        }
    }
}
