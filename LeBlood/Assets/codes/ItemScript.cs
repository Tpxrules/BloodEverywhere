using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
     public GameObject floatingMessagePrefab;
     public int type;
    public string text;
    public GameObject particle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" ){

                 
                if(collision.gameObject.TryGetComponent<movement>(out movement a)){
                   GameObject Item = Instantiate(particle, transform.position, transform.rotation);
                    
                  switch(type){
                    case 1:
                    //crit
                      a.critchance += 10;
                    break;
                    case 2:
                    //EB
                       a.bounceamount++;
                    break;
                    case 3:
                    //pen
                     a.penetration += 1;
                    break;
                    case 4:
                    //dmg
                    a.basedamage++;
                    break;
                      case 5:
                    //electric
                    if(collision.gameObject.TryGetComponent<closestenemy>(out closestenemy b)){
                            if(b.ElectricWave == false)
                            b.ElectricWave = true;
                            else if (b.attacktime  > 0.2f){
                                 b.attacktime -= 0.2f;
                                 b.damage++;
                            }
                                   
                          }
                    break;
                      case 6:
                    //stam
                      if( a.StaminaRate> 0.3)
                            a.StaminaRate =  a.StaminaRate - 0.3f;
                    break; 
                     case 7:
                    //FR
                      if( a.shootingrate > 0.3f)
                            a.shootingrate = a.shootingrate - 0.3f;
                    break;
                      case 8:
                    //machinegun
                     a.basedamage =   a.basedamage * 0.75f;
                    a.shootingrate = a.shootingrate / 2;

                    break;
                     case 9:
                    //crit
                      a.ORBHEAL ++;
                    break;
                      case 10:
                    //crit
                    if( a.maxstamina < 12)
                    a.maxstamina++;
                    a.staminabackdrop.SetHealth(a.maxstamina);

                    break;


                  }


                       GameObject floatingMessage = Instantiate(floatingMessagePrefab, transform.position, Quaternion.identity);
                        floatingMessage.GetComponent<FloatingMessage>().SetMessage(text);
                        
                        

                  }
                 
           Destroy(gameObject);
     

    } 
}}

