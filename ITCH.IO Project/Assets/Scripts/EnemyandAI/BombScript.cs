using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject Particle_Explosion;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (gameObject.tag == "Fruit")
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(ExplosionTimer());
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Bomb")
            {
                Explode();
            }
        }
        if (collision.gameObject.tag == "AirPlane")
        {
            if (gameObject.tag == "Bomb")
            {
                Explode();
            }
        }
    }

    public void Explode()
    {
        print("Kaboom");
        Instantiate(Particle_Explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(2f);
        Explode();
    }

}
