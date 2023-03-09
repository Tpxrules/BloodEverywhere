using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallengeScript : MonoBehaviour
{
        public Image slides;
        public float timeinside = 0 ;
        public float winningtime = 5;
        bool inside = false;
        float divide;
        public bool total = false;
      
      private void OnTriggerEnter2D(Collider2D other) {
       if( other.gameObject.tag == "Player" ){
         
        inside = true;
        
       }
       
      
    }
    void FixedUpdate(){
        float noom = timeinside/winningtime;
        slides.fillAmount = noom;
        
        if(inside)
        timeinside += Time.deltaTime;

        if (timeinside >= winningtime)
        //win
         Destroy(gameObject);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if( other.gameObject.tag == "Player" ){
            if(!total)
            timeinside = 0;
            inside = false;
        
       }
    }
    }
