using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public int damage;
     public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
           Invoke("Destroy", 3);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

  

   void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if( other.gameObject.tag == "Player" ){
         GameObject sploch = Instantiate(blood, transform.position, transform.rotation);
        player.gameObject.GetComponent<movement>().TakeDamage(damage);
          Destroy(gameObject);
       }
       
      
    }
}
