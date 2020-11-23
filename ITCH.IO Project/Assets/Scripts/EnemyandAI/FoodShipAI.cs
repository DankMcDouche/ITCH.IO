using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShipAI : MonoBehaviour
{
    public Rigidbody rb;
    public List<GameObject> FruitList;

    private Vector3 BombSpawnPosition;

    public bool Direction;
    public float Speed;
    public float DropTimer;
    private float Timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DropTimer)
        {
            BombSpawnPosition = new Vector3(transform.position.x, transform.position.y - 1, 0);
            Instantiate(FruitList[Random.Range(0, FruitList.Count)], BombSpawnPosition, Quaternion.identity);

            Timer = 0;
        }
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
