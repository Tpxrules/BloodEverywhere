using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleforcamera : MonoBehaviour
{
   public GameObject ana;
    public Vector3 no;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          no = (Input.mousePosition - transform.position) / 2;
          if (no.x > 2){
               no.x = 2;
          }
           if (no.y > 2){
               no.y = 2;
          }
         ana.transform.position = no + transform.position;
      
      
    }
}
