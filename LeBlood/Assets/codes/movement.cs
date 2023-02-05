using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody2D body;
    public Transform pls;
    public GameObject BulletPrefab;
    public GameObject meleePrefab;
    public float horizontal;
    public float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20.0f;
        public int maxHealth = 100; // maximum health of the player
        public int currentHealth; // current health of the player
        public HealthBar healthBar;
        public float StaminaRate = 0.2f;
        private float timesincelastrecover;
        public HealthBar stamina;
        public int maxstamina = 5; // maximum stamina of the player
        public int currentstamina; // current stamina of the player
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
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        currentstamina = maxstamina;
                healthBar.SetMaxHealth(maxHealth);
                stamina.SetMaxHealth(maxstamina);    
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        // check if player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // do death related actions here, such as calling a game over screen
        Destroy(gameObject);
    }

    void Update()
    {
         timesincelastrecover += Time.deltaTime;
        if (timesincelastrecover > StaminaRate ){
                timesincelastrecover = 0;
                if(  currentstamina < maxstamina){
                     currentstamina++;
                     stamina.SetHealth(currentstamina);                     
                }                      
        } 
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
          if (Input.GetButtonDown("Fire2") && currentstamina == 5)
        {
          currentstamina = 0;
            stamina.SetHealth(currentstamina);
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
