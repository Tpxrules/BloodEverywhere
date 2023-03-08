using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float amountofdamage = 1;
    public int bouncers = 0;
    int hits = 0;
    public int pen = 1;
    public bool fanta = false;
        public GameObject blood;
    public void Start()
    {
        if(amountofdamage >= 1)
         transform.localScale  = new Vector3((amountofdamage-1)*0.05f + transform.localScale.x ,(amountofdamage-1)*0.05f + transform.localScale.y ,(amountofdamage-1)*0.05f +transform.localScale.z );
       else
       
         transform.localScale  = new Vector3(amountofdamage* transform.localScale.x , amountofdamage * transform.localScale.y ,amountofdamage*transform.localScale.z );
      
        Invoke("Destroy", 3);
    }

        public void leset(float x , int y , int z){
            bouncers = z;
            amountofdamage = x;
            pen  = y;
        }
    void Destroy()
    {
        hits++;
          GameObject sploch = Instantiate(blood, transform.position, transform.rotation);
        if(hits>= pen){
             
                  Destroy(gameObject);
        }
     
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "chest" ){
                Rigidbody2D a = collision.gameObject.GetComponent<Rigidbody2D>();
                Vector3 difference = collision.transform.position - transform.position;
                difference.Normalize();
                collision.transform.position = collision.transform.position + difference/2;
              
                  if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
                      
                      //  if(fanta){
                       //     enemyComponent.hurtfriend(amountofdamage);
                     //   }
                         enemyComponent.TakeDamamge(amountofdamage , bouncers);
                         enemyComponent.ouchie();

                  }
                  
                Destroy();
         //  Destroy(gameObject);
     

    } 





}
}
