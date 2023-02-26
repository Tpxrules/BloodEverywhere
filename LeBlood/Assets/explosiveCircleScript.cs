using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveCircleScript : MonoBehaviour
{
      public GameObject boom = null;
      public float maxtime = 0.5f;
    float time = 0;
         void Update(){
            time += Time.deltaTime;
            if(time > maxtime){
                doov();
                Destroy(gameObject);
            }
        }

          public void doov(){
     GameObject sploch = Instantiate(boom, transform.position, transform.rotation);
       
                   
                        Destroy(gameObject);
    }
}

