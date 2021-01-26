using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public PlayerHealthScript PHealth;
    public BombScript bombScript;
    public GameManagerScript GameManager;
    public bool WeaponMode;
    private Material Clr;

    void Start()
    {
        Clr = GetComponent<Renderer>().material;
        PHealth = FindObjectOfType<PlayerHealthScript>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        if (WeaponMode)
        {
            Clr.color = Color.green;
        }
        else
        {
            Clr.color = Color.red;
        }

    }
    [SerializeField] void OnCollisionEnter(Collision collision)
    {
        if (WeaponMode)
        {
            if (collision.gameObject.CompareTag("Fruit"))
            {
                GameManager.CalculateScore(100);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Bomb"))
            {
                bombScript = collision.gameObject.GetComponent<BombScript>();
                bombScript.Explode();
                PHealth.TakeDamage(50);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Fruit"))
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Bomb"))
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(0,1000,0);
            }
        }
    }
}
