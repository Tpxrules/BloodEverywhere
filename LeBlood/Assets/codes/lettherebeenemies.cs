using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettherebeenemies : MonoBehaviour
{ 
     public float spawntime = 0.1f; 
     private float timesincelastspawn;
          public GameObject teddy1;
           public GameObject teddy2;
            public GameObject slime;
        public GameObject b;
    // Update is called once per frame
    void Update()
    {

       timesincelastspawn += Time.deltaTime;
        if (timesincelastspawn >= spawntime )
        { 
          timesincelastspawn = 0f;


          switch(Random.Range(0,6)){
               case 1:
                Instantiate(teddy1, new Vector2(Random.Range(-10,10),Random.Range(-10,10)), Quaternion.identity);
               break;
               case 2:
                 Instantiate(teddy2, new Vector2(Random.Range(-10,10),Random.Range(-10,10)), Quaternion.identity);
               break;

               case 3:
                 Instantiate(b, new Vector2(Random.Range(-10,10),Random.Range(-10,10)), Quaternion.identity);
               break;

               case <3:
                 Instantiate(slime, new Vector2(Random.Range(-10,10),Random.Range(-10,10)), Quaternion.identity);
               break;
               
          }
          
             
            }

        
    }
}
