using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOver : MonoBehaviour
{
    public bool mouseOver;
    
    public void MouseEnter()
    {
        mouseOver = true;
    }

    public void MouseExit()
    {
        mouseOver = false;
    }
}
