using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public void Start()
    {
        Invoke("Destroy", 1);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

 
}
