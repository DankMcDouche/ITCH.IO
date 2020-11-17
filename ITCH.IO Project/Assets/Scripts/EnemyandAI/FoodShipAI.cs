using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShipAI : MonoBehaviour
{
    public Rigidbody rb;
    public bool Direction;
    public float Speed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (Direction)
        {
            rb.MovePosition(rb.position + transform.up * Speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + transform.up * -Speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Direction = !Direction;
    }
}
