using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettherebeenemies : MonoBehaviour
{ 
  public int range = 20;
  public int size;
  public float spawntime ; 
  public int spawnamount = 2;
  public int asa  = 1;
  private float timesincelastspawn;
  public GameObject[] c;
              
  public void speedup(){
      spawnamount++;

      if(spawnamount % 2 == 0)
        asa = spawnamount/2;

     if(spawntime  > 0.2)
    
            spawntime = spawntime - 0.1f;   
  }
    // Update is called once per frame
  void Update()
  {  
    timesincelastspawn += Time.deltaTime;
    if (timesincelastspawn >= spawntime )
    { 
      timesincelastspawn = 0f;
       for(int i = 0 ; i < asa ; i++)
      Instantiate(c[Random.Range(0,size)], new Vector2(Random.Range(-range,range),Random.Range(-range,range)), Quaternion.identity);
        
               
    }          
  }      
}

