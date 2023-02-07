using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public int amountofdamage = 1;
        public GameObject blood;
    public void Start()
    {
        Invoke("Destroy", 3);
    }

        public void leset(int x){
            amountofdamage = x;
        }
    void Destroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag != "player" ){


                  if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){

                         enemyComponent.TakeDamamge(amountofdamage);

                  }
                  
         GameObject sploch = Instantiate(blood, transform.position, transform.rotation);
           Destroy(gameObject);
     

    } 





}
}
