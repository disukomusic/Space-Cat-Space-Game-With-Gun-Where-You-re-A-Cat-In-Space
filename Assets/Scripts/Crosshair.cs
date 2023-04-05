using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Update()
    {
        //todo: replace with Hunter.Utility.GetMouse.....
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector3 cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition ).direction;
        Vector3 flatAimTarget = screenPoint  + cursorRay  / Mathf.Abs( cursorRay.y ) * Mathf.Abs( screenPoint .y - Player.Instance.transform.position.y );
        Debug.DrawRay(Player.Instance.transform.position, flatAimTarget, Color.red);

        transform.position = flatAimTarget;
    }
}
