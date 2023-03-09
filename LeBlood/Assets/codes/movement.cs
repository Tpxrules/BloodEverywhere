using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class movement : MonoBehaviour
{  
  [SerializeField] public TextMeshProUGUI text;
  public AudioSource revive;
  public GameOverScreen GOS;
  public GameObject bloop;
  public bool magnet = false;
    public Animator animator;
    Rigidbody2D body;
    public Transform pls;
    public GameObject BulletPrefab;
    public GameObject meleePrefab;
    float horizontal;
    float vertical;
    public bool isInvincible = false;
    float moveLimiter = 0.7f;
    private movement stats;
    public float runSpeed = 20.0f;
        public int maxHealth = 100; // maximum health of the player
        public float currentHealth; // current health of the player
        public newhealthbar healthBar;     
        private float timesincelastrecover;
        public newhealthbar stamina;
        public newhealthbar staminabackdrop;     
        public int currentstamina; // current stamina of the player
        float bulletForce = 400;
        public bool held = false;
        public float lastshot;
        //implementing Dashing.
        public float dashforce = 1;
        float timer;
        private bool dash;
        //making multi attack possible
        public AudioSource dashing;
        public AudioSource damagesound;
        public int attacktype;
        public int monee = 0;
        public int chanceOfantom = 0;
        private float dashdelay = 3;
        private float lastdashed;
private float stuntime = 0.5f;
private float timestunned = 2;

public void ZAWARLDO(){
  currentHealth = maxHealth;
  revive.Play();
  StartCoroutine(gofaster());
  //playeffect;
}
  public IEnumerator gofaster()
    {
  
       runSpeed = runSpeed*2;
        yield return new WaitForSeconds(3);
        runSpeed = runSpeed/2;
       
    }
public void updatehealth(){
  int no = (int)currentHealth;
healthBar.SetHealth(no);
}
public int chance(){

return Random.Range(0,100) ;
}
    public void stun(){
      timestunned = 0;
    }
    public void recoverxp(){
          if(  currentstamina < staticinfo.maxstamina){
                    
                     currentstamina++;
                     stamina.SetHealth(currentstamina);                     
                }                      
    }
     void melee()
    {
         GameObject melee = Instantiate(meleePrefab, pls.position, pls.rotation);
           currentHealth = maxHealth;
             updatehealth();
    }
    
    void Start()
    {

        stats = GetComponent<movement>();
        gameObject.GetComponent<TrailRenderer>().enabled=false; 
        body = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        currentstamina = staticinfo.maxstamina;
                healthBar.SetMaxHealth(maxHealth);
                stamina.SetMaxHealth(12);    
                staminabackdrop.SetMaxHealth(12); 
                staminabackdrop.SetHealth(5);
    }
/*
public IEnumerator Iframez(){
    gameObject.GetComponent<Collider2D>().enabled=false; 
         yield return new WaitForSeconds(0.4f);
    gameObject.GetComponent<Collider2D>().enabled=true; 
}
*/
 public void TakeDamage(float damage)
{       
       // StartCoroutine(Iframez());
        damagesound.Play();
        currentHealth -= damage;
        updatehealth();
        // check if player is dead
        if (currentHealth <= 0)
        {
          if(staticinfo.DIO > 0){
            staticinfo.DIO--;
            ZAWARLDO();
          }else
            Die();
            return;
        }

}
 public void TakeSelfDamage(float damage)
{
       
        currentHealth -= damage;
       updatehealth();
        // check if player is dead
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

}




  void Shoot()
    {
      

      switch(attacktype){
          case 1:


               GameObject bullet = Instantiate(BulletPrefab, pls.position, pls.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pls.up * bulletForce );
         Bullet c = bullet.GetComponent<Bullet>();
        if(chance()  < chanceOfantom){
            c.fanta = true;
        }
         
        if(chance()  < staticinfo.critchance){

           c.leset(staticinfo.basedamage*3 , staticinfo.penetration , staticinfo.bounceamount);
        }else{
            c.leset(staticinfo.basedamage , staticinfo.penetration, staticinfo.bounceamount);
        }
        if(chance() >= staticinfo.FreeAmmoChance)
        TakeSelfDamage(staticinfo.basedamage);
          break;
          case 2:
             GameObject fastbullet = Instantiate(BulletPrefab, pls.position, pls.rotation);
        Rigidbody2D a = fastbullet.GetComponent<Rigidbody2D>();
        a.AddForce(pls.up * bulletForce *2);
         
        Bullet b = fastbullet.GetComponent<Bullet>();
            b.leset(3, staticinfo.penetration , staticinfo.bounceamount);


          TakeSelfDamage(2);
          break;
          default:
          attacktype = 1;
          break;



      }

      
    }
    private void Die()
    {
        // do death related actions here, such as calling a game over screen
       GOS.Setup(monee);
    //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    
      //  Destroy(gameObject);
    }
    public void moneeGain(){
               monee++;
              string s =  monee.ToString();
              text.text =  s ;
    }
    void Update()
    {
      
      



         timer += Time.deltaTime;

        if (timer > 1 && dash==true)
        {
          dash = false;
          
           GameObject Sigil = Instantiate(bloop, transform.position, transform.rotation);
           gameObject.GetComponent<TrailRenderer>().enabled=false; 
           gameObject.GetComponent<Collider2D>().enabled=true; 
        }
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();
        
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float xcomponent = Mathf.Cos(rotationZ * Mathf.PI / 180) * dashforce;
        float ycomponent = Mathf.Sin(rotationZ * Mathf.PI / 180) * dashforce;

        Vector3 dashermeter = new Vector3(xcomponent, ycomponent, 0f )/2;

                                    if (Input.GetButtonDown("Fire1") && held ==false)
                                      held = true;
                                     if (Input.GetButtonUp("Fire1") && held ==true)
                                       held = false;


        timestunned +=Time.deltaTime;
         lastshot += Time.deltaTime;
        lastdashed +=Time.deltaTime;
         timesincelastrecover += Time.deltaTime;
        if (timesincelastrecover > staticinfo.StaminaRate ){
                timesincelastrecover = 0;
            recoverxp();
        } 
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

      if(timestunned<stuntime){
        horizontal = 0;
        vertical = 0;
      }



        if (held ==true && currentHealth > 1 && lastshot > staticinfo.shootingrate)
        {
            lastshot = 0;
            Shoot();
        }



          if (Input.GetButtonDown("Fire2") && currentstamina > 1)
        {
            stun();
          //no longer melee now spawns sigil
          currentstamina = currentstamina-2;
            stamina.SetHealth(currentstamina);
            melee();

      
        }



          if (Input.GetButtonDown("Dash") && currentHealth > 2 && currentstamina > 3  && lastdashed > dashdelay)
        {
          lastdashed = 0;
          dashing.Play();
          timer = 0;
          dash = true;
             GameObject melee = Instantiate(meleePrefab, transform.position ,pls.rotation);
             gameObject.GetComponent<TrailRenderer>().enabled=true; 
            gameObject.GetComponent<Collider2D>().enabled=false; 
             TakeDamage(2);
             currentstamina = currentstamina - 4;
              stamina.SetHealth(currentstamina);
               body.velocity=new Vector2(0,0);
                body.AddForce( dashermeter);
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
