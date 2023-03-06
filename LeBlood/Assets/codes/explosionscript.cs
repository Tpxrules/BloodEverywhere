using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionscript : MonoBehaviour
{
    private GameObject player;
    float time;
    // Start is called before the first frame update
    void Start()
    {
          player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        if(time > 0.4f){
            Destroy(gameObject);
        }
        
    }
      private void OnTriggerEnter2D(Collider2D other) {
       if( other.gameObject.tag == "Player" ){
        
         player.gameObject.GetComponent<movement>().TakeDamage(20);
        
       }
       
      
    }
}
