using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform pls;
    public GameObject BulletPrefab;

    public float bulletForce = 20f;

 
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet =  Instantiate(BulletPrefab,pls.position,pls.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pls.up * bulletForce);
    }



}
