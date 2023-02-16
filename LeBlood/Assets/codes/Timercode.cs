using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timercode : MonoBehaviour
{

   [SerializeField] public TextMeshProUGUI text;

    private float startTime;
    public lettherebeenemies boo;
      private float timesincebump;
    // Start is called before the first frame update
    void Start()
    {
       startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        
        float t = Time.time - startTime;
         float d = Time.time - timesincebump;
         if(d > 30){
            timesincebump = Time.time;
           boo.speedup();
         }
        
        string minute = ((int) t / 60 ).ToString();
        string seconds =  Mathf.Floor((t%60)).ToString();
        if(Mathf.Floor((t%60)) < 10)
 text.text = minute + ":0"  + seconds ;
        else
        text.text = minute + ":" + seconds ;

        
    }
}
