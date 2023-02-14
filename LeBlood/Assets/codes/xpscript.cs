using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpscript : MonoBehaviour
{
     public GameObject blood;
    private Transform target;
    public float speed;
    private float distance;
    private movement a;
   

    private void Start(){
       
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        a = GameObject.FindWithTag("Player").GetComponent<movement>();
    }

   
    

     public void Update() {
        distance = Vector2.Distance(transform.position,target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
                  if(distance<3 || a.magnet == true) 
                     transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);

         
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if( other.gameObject.tag == "Player" ){
         GameObject sploch = Instantiate(blood, transform.position, transform.rotation);
         a.recoverxp();
          Destroy(gameObject);
       }
       
      
    }
}
