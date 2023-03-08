using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuformainmenu : MonoBehaviour
{
    public GameObject main;
    public GameObject controlz;
    public void controls(){
        main.SetActive(false);
        controlz.SetActive(true);
    }
    public void manu(){
    controlz.SetActive(false);
    main.SetActive(true);
    }

}
