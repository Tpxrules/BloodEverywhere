using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Transform pls;
    public GameObject BulletPrefab;
     public GameObject meleePrefab;

    public float bulletForce ;



    void Shoot()
    {

        GameObject bullet = Instantiate(BulletPrefab, pls.position, pls.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pls.up * bulletForce );
    }
     void melee()
    {
         GameObject melee = Instantiate(meleePrefab, pls.position, pls.rotation);
     
    }

    Rigidbody2D body;

    public float horizontal;
    public float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
          if (Input.GetButtonDown("Fire2"))
        {
            melee();
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
