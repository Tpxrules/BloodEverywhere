using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritChance : MonoBehaviour
{
    public bool crit = false;
    public bool pen = false;
    public GameObject particle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" ){

                 
                if(collision.gameObject.TryGetComponent<movement>(out movement a)){

                            GameObject Item = Instantiate(particle, transform.position, transform.rotation);
                        if(crit)
                            a.critchance += 10;
                        if(pen)
                            a.penetration += 1;
                        



                        
                        

                  }
                 
           Destroy(gameObject);
     

    } 
}
}
