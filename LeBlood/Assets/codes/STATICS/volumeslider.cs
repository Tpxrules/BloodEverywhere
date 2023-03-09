using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class volumeslider : MonoBehaviour
{


  public Slider sliderUI;
      public void setvol(){
        staticinfo.vol = sliderUI.value;
    }
}
