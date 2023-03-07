using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float time = 0;
    public GameObject circle = null;
       private float duration = 0.2f;
          public GameObject Electricity;
     SpriteRenderer sprite;
    private Transform target;
   
  
    public float speed;
    private float distance;
    public bool ranger;
    public float range;
    public GameObject floatingMessagePrefab;
      public GameObject a;
      public GameObject b;
      public GameObject c;
      public GameObject d;
      public GameObject e;
      public GameObject f;
        public GameObject xporb;
        public bool ignited;
        public bool exploder;
        public bool bounced = false;
        int bouncies;
    [SerializeField] float health, maxHealth = 3f;
 Color red = new Color (1, 0.5f, 0.5f, 1); 
 Color white = new Color (1, 1, 1, 1); 
    private void Start(){
        sprite = GetComponent<SpriteRenderer>();
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      
    }
    public void ouchie(){
             StartCoroutine(ouchies());
    }
    public  IEnumerator ouchies()
    {
     
        sprite.color = red;
          gameObject.GetComponent<Collider2D>().enabled=false; 
        
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<Collider2D>().enabled=true; 
        
        sprite.color =  white; 
    }
    public void TakeDamamge(float damageAmount, int bounces){
        bouncies = bounces;
          if(bouncies >1){
            bouncies--;
                hurtfriend(damageAmount);
          }

        health -=damageAmount;
        if (damageAmount > 0) {
            GameObject floatingMessage = Instantiate(floatingMessagePrefab, transform.position, Quaternion.identity);
            floatingMessage.GetComponent<FloatingMessage>().SetMessage(damageAmount.ToString());
        }
        if(health<=0){
                //spawning le funny blood
                int number;
                number =Random.Range(1,6);
                switch(number){
                    case 1:
                      GameObject blood1 = Instantiate(a, transform.position, transform.rotation);
                    break;
                    case 2:
                        GameObject blood2 = Instantiate(b, transform.position, transform.rotation);
                    break;
                    case 3:
                        GameObject blood3 = Instantiate(c, transform.position, transform.rotation);
                    break;
                    case 4:
                        GameObject blood4 = Instantiate(d, transform.position, transform.rotation);
                    break;
                    case 5:
                        GameObject blood5 = Instantiate(e, transform.position, transform.rotation);
                    break;
                    case 6:
                         GameObject blood6 = Instantiate(f, transform.position, transform.rotation);
                    break;
                }
                

            
             GameObject xp = Instantiate(xporb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void electric(){
              GameObject bzzzzzzz = Instantiate(Electricity, transform.position, transform.rotation);
    }

     public void Update() {
        if(ignited)
        time += Time.deltaTime;
        if(time> 0.5f)
        doov();
       // FindClosestEnemy ();
	
        distance = Vector2.Distance(transform.position,target.transform.position);
        Vector2 direction = target.transform.position - transform.position;

        if(direction.x > 1){
            transform.localScale  = new Vector3(1,1,1);
        }
         else
          transform.localScale  = new Vector3(-1,1,1);
       
         if(ranger){

                if(distance>range)
                     transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
                

         }else if(exploder){
                 if(distance>range  && ignited == false){
                     transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
                
                }else{
                    //boom
                    if(ignited == false){
                     GameObject boo = Instantiate(circle, transform.position, transform.rotation);
                    }
                    ignited = true;
                    
                   


                }
         }else
                    transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
         
    }

    float distanceToClosestEnemy = Mathf.Infinity;
	Enemy closestEnemy = null;
    // Start is called before the first frame update

 
  
//  playa = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    public void doov(){
          
                        Destroy(gameObject);
    }
	public void hurtfriend(float z )
	{

            distanceToClosestEnemy = Mathf.Infinity;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        if(allEnemies.Length > 1){

		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy && currentEnemy.transform.position != transform.position) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

            closestEnemy.TakeDamamge(z , bouncies);
           
            // add amount of bounces.
        
		
	}
    
    }
}
