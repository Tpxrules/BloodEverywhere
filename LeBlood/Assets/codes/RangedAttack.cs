using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float rateOattack = 1f;


    private float timer;
    private GameObject player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update(){
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position,player.transform.position );
        if(distance<10){
            timer += Time.deltaTime;
            if(timer>rateOattack){
            timer = 0;
            shoot();
        }
        }

    }

    void shoot(){
        Instantiate(bullet,bulletPos.position,Quaternion.identity);
    }
}
