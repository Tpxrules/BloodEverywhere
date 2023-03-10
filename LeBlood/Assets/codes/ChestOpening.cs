using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
        SpriteRenderer sprite;
        public Animator animator;
        public int size;
        public GameObject[] items;
        float timmy;
         Color white = new Color (1, 1, 1, 1); 
         Color minus = new Color (0, 0, 0, 0.1f); 
         public bool it = false;
    //    public ParticleSystem particles;
       
    // Start is called before the first frame update
    void Start()
    {
      sprite = GetComponent<SpriteRenderer>();
      gameObject.GetComponent<ParticleSystem>().Stop(); 
      //   animator.SetBool("bop", true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    public IEnumerator disappear(){
        timmy =  Time.time;
        while(Time.time-timmy < 5){
               yield return new WaitForSeconds(0.1f);
          white = white - minus;
          sprite.color = white;
        }
        Destroy(gameObject);
    }
    public void open(){
      if(it){
            staticinfo.spawning = true;
            staticinfo.startTime = Time.time;
      }
    
       GameObject Item = Instantiate(items[Random.Range(0,size)], transform.position, transform.rotation);
          gameObject.GetComponent<Collider2D>().enabled = false;
         gameObject.GetComponent<ParticleSystem>().Play(); 
         gameObject.GetComponent<AudioSource>().Play();
         animator.SetBool("bop", true);
         
         StartCoroutine(disappear());
    }

   
 
}
