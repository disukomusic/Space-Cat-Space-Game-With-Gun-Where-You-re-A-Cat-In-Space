using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crosshair : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
