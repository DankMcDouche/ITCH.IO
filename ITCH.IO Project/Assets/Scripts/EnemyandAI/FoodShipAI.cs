using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShipAI : MonoBehaviour
{
    public GameManagerScript GameManager;
    public Rigidbody rb;
    public List<GameObject> FruitList;

    private Vector3 BombSpawnPosition;

    public float Speed;
    public float DropTimer;
    private float Timer;
    public float DropOffsetY;

    public bool CanDropBomb;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        CanDropBomb = true;
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DropTimer && CanDropBomb)
        {
            BombSpawnPosition = new Vector3(transform.position.x, transform.position.y - DropOffsetY, 0);
            Instantiate(FruitList[Random.Range(0, FruitList.Count)], BombSpawnPosition, Quaternion.identity);

            Timer = 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.right * Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.Rotate(0,180,0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            GameManager.CalculateScore(1000);
            CanDropBomb = false;
            rb.useGravity = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            GameManager.SpawnShip();
            Destroy(gameObject);
        }
    }
}
