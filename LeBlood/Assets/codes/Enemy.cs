using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
    [SerializeField] float health, maxHealth = 3f;

    private void Start(){
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamamge(float damageAmount){
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

     public void Update() {
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
                    ignited = true;
                }
         }else
                    transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
         
    }
}
