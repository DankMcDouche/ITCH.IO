using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public PlayerScript Player;
    public GameManagerScript GameManager;
    public bool WeaponMode;
    private Material Clr;

    void Start()
    {
        Clr = GetComponent<Renderer>().material;
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
                print("Weapon Collide Fruit Correctly");
                GameManager.CalculateScore(100);
            }
            else if (collision.gameObject.CompareTag("Bomb"))
            {
                print("Weapon Wrongly Collides Bomb");
                Player.Health -= 2;
            }
            Destroy(collision.gameObject);
        }
        else
        {
            if (collision.gameObject.CompareTag("Fruit"))
            {
                print("Weapon Wrongly Collides Fruit");
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Bomb"))
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(0,1000,0);
                print("Weapon Collides Bomb Correctly");
            }
        }
    }
}
