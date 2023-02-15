using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritChance : MonoBehaviour
{

    public GameObject particle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" ){

                 
                if(collision.gameObject.TryGetComponent<movement>(out movement a)){
                         GameObject Item = Instantiate(particle, transform.position, transform.rotation);
                         a.critchance += 10;

                  }
                 
           Destroy(gameObject);
     

    } 
}
}
