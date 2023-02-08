using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodies : MonoBehaviour
{
   private Transform target;
    public float speed;
    private float distance;
    public bool ignited = false;
    public float range;

        public GameObject xporb;
    [SerializeField] float health, maxHealth = 3f;

    private void Start(){
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamamge(float damageAmount){
        health -=damageAmount;
        if(health<=0){  
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
       


                if(distance>range  && ignited == false){
                     transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
                
                }else{
                    ignited = true;
                }
      
    }
}
