using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleforcamera : MonoBehaviour
{
   public GameObject here;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         here.transform.position =( transform.position - Input.mousePosition ) / 2 + transform.position;
      
      
    }
}
