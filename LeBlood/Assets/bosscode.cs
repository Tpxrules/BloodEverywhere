using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscode : MonoBehaviour
{

    float timesincelastattack;
    
    private Transform target;
    private movement zaplaya;
        private float distance;
        public int range;
        public int speed;
        public int size;
        private int b = 0;
        public int attackfreq ;
    // Start is called before the first frame update
    void Start()
    {
          target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
          zaplaya = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
    }




    void attack(){

        Random.Range(0,size);
         b++;
        switch (size){
       
            case 1:
                Debug.Log("attacked" + b);
            break;

            default:
            break;
        }



    }

    // Update is called once per frame
    void Update()
    {
      
         distance = Vector2.Distance(transform.position,target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
             if(distance>range)
                     transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
                     else{ 
                          timesincelastattack += Time.deltaTime;
                        if(timesincelastattack > attackfreq){
                            timesincelastattack = 0;
                            //attacking boi
                                attack();

                     }
                     }
                

        
    }
}
