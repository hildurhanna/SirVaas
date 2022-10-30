using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private bool hasTappedRight;
    private bool hasTappedLeft;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            hasTappedRight = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            hasTappedLeft = true;
        }
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || hasTappedRight)
        {
            transform.Rotate(0,0,-90);
        }
        if (Input.GetKey(KeyCode.A) || hasTappedLeft)
        {
            transform.Rotate(0,0,90);
        }

        hasTappedLeft = false;
        hasTappedRight = false;
        transform.position += transform.up;
    }
}
