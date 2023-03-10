using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class vignettestuff : MonoBehaviour
{

     public PostProcessVolume _ps;
    private Vignette _vg;
    public float test;
    public float test2;
    // Start is called before the first frame update
    void Start()
    {
        
         _ps.profile.TryGetSettings(out _vg);
    }

   
   
public void updatevignette(float maxs , float current){
test  =   (((maxs - current)/maxs *55f) +45)/100;

  _vg.intensity.value = (((maxs - current)/maxs *25f) +45)/100;
}
}
