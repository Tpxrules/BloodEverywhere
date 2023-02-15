using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
        public Animator animator;
        public int size;
        public GameObject[] items;
    //    public ParticleSystem particles;
       
    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<ParticleSystem>().Stop(); 
      //   animator.SetBool("bop", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open(){
       GameObject Item = Instantiate(items[Random.Range(0,size)], transform.position, transform.rotation);
          gameObject.GetComponent<Collider2D>().enabled = false;
         gameObject.GetComponent<ParticleSystem>().Play(); 
         gameObject.GetComponent<AudioSource>().Play();
         animator.SetBool("bop", true);
    }

   
 
}
