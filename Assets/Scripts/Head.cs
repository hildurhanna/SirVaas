using System;
using UnityEngine;

public class Head : MonoBehaviour
{
    private bool hasTappedRight;
    private bool hasTappedLeft;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }


    public void Update()
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

    public void FixedUpdate()
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
