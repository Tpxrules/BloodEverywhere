using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
   public GameObject blood;



    private Transform target;
    public void Start()
    {
        Invoke("Destroy", 1);
           
        target = GameObject.FindGameObjectWithTag("Hand").GetComponent<Transform>();
        
    }


    void Update(){
           transform.position = target.transform.position;
             transform.rotation = target.transform.rotation;
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
