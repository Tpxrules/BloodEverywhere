using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class explosionscript : MonoBehaviour
{
  private CinemachineImpulseSource _shake;
    private GameObject player;
    float time;
    // Start is called before the first frame update
    void Start()
    {
       _shake = GetComponent<CinemachineImpulseSource>();
          player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        if(time > 0.4f){
         _shake.GenerateImpulse();
            Destroy(gameObject);
        }
        
    }
      private void OnTriggerEnter2D(Collider2D other) {
       if( other.gameObject.tag == "Player" ){
        
         player.gameObject.GetComponent<movement>().TakeDamage(20);
        
       }else  if( other.gameObject.tag == "Enemy" ){
          if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
                      
                      //  if(fanta){
                       //     enemyComponent.hurtfriend(amountofdamage);
                     //   }
                         enemyComponent.TakeDamamge(2 , 1);
                         enemyComponent.ouchie();

                  }
       }
       
      
    }
}
