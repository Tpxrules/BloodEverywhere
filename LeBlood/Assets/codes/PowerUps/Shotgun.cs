using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject bulletPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

         
            // Spawn 3 bullets at different angles

            /*
            for (int i = 0; i < 3; i++)
            {
                float angle = i * 20f - 20f; // Calculate angle based on the index
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle); // Create a rotation based on the angle
                GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation); // Instantiate the bullet with the rotation
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up*500f);
            }
            */
            Destroy(gameObject); // Destroy the pickup object
        }
    }
}
