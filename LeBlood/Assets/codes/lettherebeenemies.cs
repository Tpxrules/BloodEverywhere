using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettherebeenemies : MonoBehaviour
{
          public GameObject a;
        public GameObject b;
    // Update is called once per frame
    void Update()
    {
            if(Random.Range(0,100) > 98){
                 if(Random.Range(0,100) > 50)
                      Instantiate(a, new Vector2(Random.Range(0,10),Random.Range(0,10)), Quaternion.identity);
                 else
                   Instantiate(b, new Vector2(Random.Range(0,10),Random.Range(0,10)), Quaternion.identity);
            }

        
    }
}
