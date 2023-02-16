using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagelava : MonoBehaviour
{
        Collider2D player;
        float timmy;
    private bool damage = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

     private void OnTriggerEnter2D(Collider2D other) {
       if( other.gameObject.tag == "Player" ){
             player = other;
       damage = true;
       timmy = Time.time;
        
      
        
       }
       
      
    }
    void FixedUpdate(){
       timmy  +=Time.deltaTime;
                if(timmy > 0.2f  && damage ){
                    timmy = 0;


                     player.gameObject.GetComponent<movement>().TakeDamage(4);
                }
              
         
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if( other.gameObject.tag == "Player" ){
            damage = false;
           
        
       }
    }
    
}
