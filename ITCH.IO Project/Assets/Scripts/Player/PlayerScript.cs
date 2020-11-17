using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    public float BaseSpeed;
    public float Speed;
    public bool IsGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Movement();
        Combat();
    }


    public void Combat()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Attack
        }
    }

    public void Movement()
    {
        if (transform.position.y <= -2.8f)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
        if (!IsGrounded)
        {
            Speed = 2;
        }
        else
        {
            Speed = BaseSpeed;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.MovePosition(rb.position + transform.right * Speed * Time.fixedDeltaTime);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.MovePosition(rb.position + transform.right * -Speed * Time.fixedDeltaTime);
        }
        if (IsGrounded == true && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 7, 0);
        }
    }
}
