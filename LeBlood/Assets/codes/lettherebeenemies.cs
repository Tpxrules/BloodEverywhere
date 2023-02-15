using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettherebeenemies : MonoBehaviour
{ 
  public int size;
  public float spawntime ; 
  private float timesincelastspawn;
  public GameObject[] c;
              
  public void speedup(){
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

      Instantiate(c[Random.Range(0,size)], new Vector2(Random.Range(-10,10),Random.Range(-10,10)), Quaternion.identity);
        
               
    }          
  }      
}

