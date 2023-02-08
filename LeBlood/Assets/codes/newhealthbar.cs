using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class newhealthbar : MonoBehaviour
{
         public Image slides;
        public float current;
        public float max;
    public void SetMaxHealth(int health)
{
    max = health;
}

public void SetHealth(int health)
{
   current = health;
}


void  FixedUpdate(){

float noom;

noom = current/max;
slides.fillAmount = noom;
}
}
