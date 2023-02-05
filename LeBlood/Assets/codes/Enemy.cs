using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    private float distance;
    public bool ranger;
    public float range;
    [SerializeField] float health, maxHealth = 3f;

    private void Start(){
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamamge(float damageAmount){
        health -=damageAmount;
        if(health<=0){
            Destroy(gameObject);
        }
    }

     public void Update() {
        distance = Vector2.Distance(transform.position,target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
         
       
         if(ranger){

                if(distance>range)
                     transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
                

         }else
                    transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
         
    }
}
