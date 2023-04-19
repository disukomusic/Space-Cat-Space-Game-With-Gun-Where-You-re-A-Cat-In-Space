using System;
using UnityEngine;


public class FaceMouse : MonoBehaviour
{
    private void Update()
    {
        Vector3 flatAimTarget = Hunter.Utility.GetMousePositionOnGroundPlane() - transform.position;
        flatAimTarget = new Vector3(flatAimTarget.x, 0.5f, flatAimTarget.z).normalized;
        
        transform.rotation = Quaternion.LookRotation(flatAimTarget);
    }
}
