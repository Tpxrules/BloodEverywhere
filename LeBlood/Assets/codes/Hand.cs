using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Animator animator;
   public GameObject blood;
      public GameObject bloodrecieve;
    public Quaternion silly;


    private Transform target;


   

    public void Start()
    {
        Invoke("enabler", 1);
        
      
        target = GameObject.FindGameObjectWithTag("Hand").GetComponent<Transform>();
       
         spark();
           gameObject.GetComponent<BoxCollider2D>().enabled=false; 
    }


    void Update(){
        silly =   Quaternion.Euler( target.transform.rotation.x,  target.transform.rotation.y,  target.transform.rotation.z-90);
        
             transform.rotation = silly;
    }
  
    void spark(){
 GameObject splich = Instantiate(bloodrecieve, transform.position, transform.rotation);
    }
    void enabler(){
       gameObject.GetComponent<BoxCollider2D>().enabled=true; 
    }
    void Destroy()
    {
        
     Destroy(gameObject);
    }

  void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Enemy" ){

                 
                  if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
                       GameObject sploch = Instantiate(blood, transform.position, transform.rotation);
                         enemyComponent.TakeDamamge(3);

                  }
           Destroy(gameObject);
     

    } 
}
}
