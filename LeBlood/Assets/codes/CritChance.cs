using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritChance : MonoBehaviour
{
    public bool crit = false;
    public bool pen = false;
    public bool electric = false;
    public bool dmg = false;
    public bool FR = false;
    public bool stam  = false;
    public bool EB = false;
    public GameObject particle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" ){

                 
                if(collision.gameObject.TryGetComponent<movement>(out movement a)){

                            GameObject Item = Instantiate(particle, transform.position, transform.rotation);
                        if(crit)
                            a.critchance += 10;
                              if(EB)
                            a.bounceamount++;
                        if(pen)
                            a.penetration += 1;
                            if(dmg)
                            a.basedamage++;
                            if(stam && a.StaminaRate> 0.3)
                            a.StaminaRate =  a.StaminaRate - 0.3f;
                            
                            if(FR && a.shootingrate > 0.3f)
                            a.shootingrate = a.shootingrate - 0.3f;
                           
                      
                        
                          if(collision.gameObject.TryGetComponent<closestenemy>(out closestenemy b)){
                            if(b.ElectricWave == false)
                            b.ElectricWave = true;
                            else if (b.attacktime  > 0.2f){
                                 b.attacktime -= 0.2f;
                                 b.damage++;
                            }
                                   
                          }

                      
                        
                        

                  }
                 
           Destroy(gameObject);
     

    } 
}}

