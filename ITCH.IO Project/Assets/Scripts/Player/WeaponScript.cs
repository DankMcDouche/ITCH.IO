using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public PlayerScript Player;
    public bool WeaponMode;
    private Material Clr;

    void Start()
    {
        Clr = GetComponent<Renderer>().material;
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
    private void OnTriggerEnter(Collider other)
    {
        if (WeaponMode)
        {
            if (other.gameObject.tag == "Fruit")
            {
                Destroy(other);
                //Score ++
            }
            else if (other.gameObject.tag == "Bomb")
            {
                Destroy(other);
                Player.Health -= 2;
            }
        }
        else
        {
            if (other.gameObject.tag == "Fruit")
            {
                Destroy(other);
                //No Score, screen splatter
            }
            else if (other.gameObject.tag == "Bomb")
            {
                //Flies back up
            }
        }
    }
}
