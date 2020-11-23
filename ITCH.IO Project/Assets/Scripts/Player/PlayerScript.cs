using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public SceneMNGR SceneManager;
    public WeaponScript Weapon;
    
    public Rigidbody rb;
    public GameObject AttackBOX;

    public int Health;
    public float BaseSpeed;
    public float Speed;
    public bool IsGrounded;
    private bool HasAttacked;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Movement();
        Combat();
    }

    private void Update()
    {
        if (Health <= 0)
        {
            SceneManager.StartGameOverScene();
        }
    }

    public void Combat()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Weapon.WeaponMode = !Weapon.WeaponMode;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Attack
            print("Attacking");
            HasAttacked = true;
            StartCoroutine(AttackTimer());
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
            Speed = 3;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            Destroy(collision.gameObject);
            Health -= 2;
            print("OOF BOMB");
        }
        if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            Health--;
            print("OOF FRUIT");
        }
    }
    IEnumerator AttackTimer()
    {
        while (HasAttacked)
        {
            AttackBOX.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            AttackBOX.SetActive(false);
            HasAttacked = false;
        }
    }
}
