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
        Invoke("Destroy", 1);
        
      
        target = GameObject.FindGameObjectWithTag("Hand").GetComponent<Transform>();
         spark();
    }


    void Update(){
        silly =   Quaternion.Euler( target.transform.rotation.x,  target.transform.rotation.y,  target.transform.rotation.z-90);
           transform.position = target.transform.position;
             transform.rotation = silly;
    }
  
    void spark(){
 GameObject splich = Instantiate(bloodrecieve, transform.position, transform.rotation);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }

  void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag != "player" ){

                 
                  if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
                       GameObject sploch = Instantiate(blood, transform.position, transform.rotation);
                         enemyComponent.TakeDamamge(3);

                  }
           Destroy(gameObject);
     

    } 
}
}
