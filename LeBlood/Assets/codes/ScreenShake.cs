using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    private CinemachineImpulseSource impulse;

    void Start() 
    {
        impulse = GetComponent<CinemachineImpulseSource>();    
    }
    
    public void Shake()
    {
        impulse.GenerateImpulse(10f);
    }
}
