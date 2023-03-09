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
                      staticinfo.critchance += 10;
                    break;
                    case 2:
                    //EB
                       staticinfo.bounceamount++;
                    break;
                    case 3:
                    //pen
                     staticinfo.penetration += 1;
                    break;
                    case 4:
                    //dmg
                    staticinfo.basedamage++;
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
                            staticinfo.StaminaRate =  staticinfo.StaminaRate * 0.75f;
                    break; 
                     case 7:
                    //FR
                            staticinfo.shootingrate = staticinfo.shootingrate * 0.75f;
                    break;
                      case 8:
                    //machinegun
                     staticinfo.basedamage =   staticinfo.basedamage * 0.75f;
                    staticinfo.shootingrate = staticinfo.shootingrate / 2;

                    break;
                     case 9:
                    //crit
                      staticinfo.ORBHEAL ++;
                    break;
                      case 10:
                    //crit
                    if( staticinfo.maxstamina < 12)
                    staticinfo.maxstamina++;
                    a.staminabackdrop.SetHealth(staticinfo.maxstamina);

                    break;
                    case 11:
                    staticinfo.FreeAmmoChance += 10;

                    break;
                      case 12:
                    staticinfo.DIO++;

                    break;


                  }


                       GameObject floatingMessage = Instantiate(floatingMessagePrefab, transform.position, Quaternion.identity);
                        floatingMessage.GetComponent<FloatingMessage>().SetMessage(text);
                        
                        

                  }
                 
           Destroy(gameObject);
     

    } 
}}

