using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public float maxtime = 1;
    float time = 0;
         void Update(){
            time += Time.deltaTime;
            if(time > maxtime){
                Destroy(gameObject);
            }
        }
}

