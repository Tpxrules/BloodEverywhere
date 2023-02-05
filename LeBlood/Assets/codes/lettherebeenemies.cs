using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettherebeenemies : MonoBehaviour
{ 
     public float spawntime = 0.1f; 
     private float timesincelastspawn;
          public GameObject a;
        public GameObject b;
    // Update is called once per frame
    void Update()
    {

       timesincelastspawn += Time.deltaTime;
        if (timesincelastspawn >= spawntime )
        { 
          timesincelastspawn = 0f;
                 if(Random.Range(0,100) > 50)
                      Instantiate(a, new Vector2(Random.Range(-10,10),Random.Range(-10,10)), Quaternion.identity);
                 else
                   Instantiate(b, new Vector2(Random.Range(-10,10),Random.Range(-10,10)), Quaternion.identity);
            }

        
    }
}
