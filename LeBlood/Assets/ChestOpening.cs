using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
        public Animator animator;
       
    // Start is called before the first frame update
    void Start()
    {
      //   animator.SetBool("bop", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open(){
         animator.SetBool("bop", true);
    }

   
  void OnCollisionEnter2D(Collision2D collision)
    {
      
        if( collision.gameObject.tag == "Bink" ){
               Destroy(gameObject);
        }
     }
}
