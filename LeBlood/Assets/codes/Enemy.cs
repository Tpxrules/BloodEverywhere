using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public bool ranger;
    [SerializeField] float health, maxHealth = 3f;

    private void Start(){
        health = maxHealth;
    }

    public void TakeDamamge(float damageAmount){
        health -=damageAmount;
        if(health<=0){
            Destroy(gameObject);
        }
    }

     public void Update() {
        distance = Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
         
       
         if(ranger){

                if(distance>4)
                     transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                

         }else
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
         
    }
}
