using System;
using UnityEngine;

public class Head : MonoBehaviour
{
    private bool hasTappedRight;
    private bool hasTappedLeft;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Pikachuu pikachuu))
        {
            pikachuu.OnEaten();
        }
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
        if (transform.position.x > 4.5f)
        {
            transform.Translate(-9,0,0, Space.World);
        }
        else if (transform.position.x < -4.5 )
        {
            transform.Translate(9,0,0,Space.World);
        }
    }
}
