using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeset : MonoBehaviour
{
   public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        setvolume();
    }

    public void setvolume(){
        music.volume = staticinfo.vol;
    }
}
