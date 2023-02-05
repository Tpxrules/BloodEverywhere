using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Animator animator;
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

        public bool held = false;
        public float shootingrate = 0.2f;
        public float lastshot;
  
     void melee()
    {
         GameObject melee = Instantiate(meleePrefab, pls.position, pls.rotation);
           currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
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
  void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, pls.position, pls.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pls.up * bulletForce );
        TakeDamage(1);
    }
    private void Die()
    {
        // do death related actions here, such as calling a game over screen
        Destroy(gameObject);
    }

    void Update()
    {
       

      

    if (Input.GetButtonDown("Fire1") && held ==false)
    held = true;
      if (Input.GetButtonUp("Fire1") && held ==true)
    held = false;


     
         lastshot += Time.deltaTime;
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
        if (held ==true && currentHealth > 1 && lastshot > shootingrate)
        {
            lastshot = 0;
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
        animator.SetFloat("HS", horizontal);
        animator.SetFloat("VS" , vertical);
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
